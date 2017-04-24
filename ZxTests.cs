using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Operations
{
    public class ZxTests
    {
        public static Zx<Family> BuildFamily =>
            from yuni in People.Someone("Sergey", isHappy: true)
            from sergey in People.Someone("Yuni", isHappy: true)
            from couple in People.MakeCouple(yuni, sergey)
            let happyCouple = couple.Happy()
            from ourKid in People.Someone("No name yet", isHappy: true)
            from family in People.MakeFamily(couple: happyCouple, kids: new List<Person> { ourKid })
            where happyCouple.IsHappy
            where family.Kids.Any()
            where yuni.IsHappy && sergey.IsHappy && ourKid.IsHappy
            select family;

        public static async Task TestBuildFamily()
        {
            var familyBuilder = ZxTests.BuildFamily;
            Console.WriteLine("Initializing...");
            await Task.Delay(500);
            Console.WriteLine("Building the family...");
            var family = await familyBuilder;
            if (!family.HasValue)
            {
                Console.WriteLine("Family is not succeeded");
            }
            Console.WriteLine(family.Value);
        }

        public class Person
        {
            public string Name { get; }
            public bool IsHappy { get; }

            public Person(string name, bool isHappy)
            {
                Console.WriteLine($"Getting a person {name}...");
                Name = name;
                IsHappy = isHappy;
            }

            public override string ToString() => Name;
        }

        public class Couple
        {
            public Person Wife { get; }
            public Person Husband { get; }
            public bool IsHappy { get; private set; }

            public Couple(Person wife, Person husband)
            {
                Wife = wife;
                Husband = husband;
                Console.WriteLine($"Creating a couple {this}...");
            }

            public Couple Happy()
            {
                Console.WriteLine($"Making the couple {this} happy...");
                IsHappy = true;
                return this;
            }

            public override string ToString() => $"<{Wife} + {Husband}>";
        }

        public class Family
        {
            public IEnumerable<Person> Kids { get; set; }
            public Person Wife { get; }
            public Person Husband { get; }
            public bool IsHappy { get; private set; }

            public Family(Person wife, Person husband, IEnumerable<Person> kids)
            {
                Wife = wife;
                Husband = husband;
                Kids = kids ?? new List<Person>();
                Console.WriteLine($"Creating a family {this}...");
            }

            public Family Happy()
            {
                Console.WriteLine($"Making the family {this} happy...");
                IsHappy = true;
                return this;
            }

            public override string ToString() =>
                $"<{Wife} + {Husband} + kids: " +
                String.Join("+", Kids.Select(kid => kid.Name)) + ">";
        }

        public static class People
        {
            public static Zx<Person> Sergey => Someone("Sergey Solovev", isHappy: false);
            public static Zx<Person> Yuni => Someone("Wahyuni Nur Aini Fuandono", isHappy: true);
            public static Zx<Person> Someone(string name, bool isHappy)
                => Zx.Get(() => new Person(name, isHappy));
            public static Zx<Couple> MakeCouple(Person wife, Person husband)
                => Zx.Get(() => new Couple(wife, husband));
            public static Zx<Family> MakeFamily(Couple couple, IEnumerable<Person> kids)
                => Zx.Get(() => new Family(couple.Wife, couple.Husband, kids));
        }
    }
}