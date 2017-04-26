using System;
using System.Collections.Generic;
using System.Linq;
using Operations.Linq;

namespace Operations
{
    public static class Mapping
    {
        public static IMapping<T> Id<T>()
            => Get<T>((IOperation<T> x) => x);

        public static IMapping<T> Get<T>(Func<IOperation<T>, IOperation<T>> mapping)
            => new Mapping<T>(mapping);

        public static IMapping<T> Get<T>(Func<T, T> mapping)
            => Get<T>(x => Operation.Get<T>(() => mapping(x.GetValue())));

        public static IMapping<T> Compose<T>(this IEnumerable<IMapping<T>> mappings)
            => Enumerable.Aggregate(mappings, Id<T>(), Compose);

        public static IMapping<T> Compose<T>(this IMapping<T> self, IMapping<T> with)
            => Mapping.Get<T>(x => self.Map(with.Map(x)));
    }
}