using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;

namespace Operations
{
    public interface IOperationContext
    {
        void PassTo(IOperationContext context);
        Dictionary<string, object> Properties { get; }
        List<Exception> Errors { get; }
        bool Succeeded { get; }
    }

    public class OperationTests
    {
        public class OperationResult : IOperationContext
        {
            public Dictionary<string, object> Properties { get; private set; }

            public List<Exception> Errors { get; private set; }

            public bool Succeeded => (Errors == null);

            public void PassTo(IOperationContext context)
            {
                Errors.ForEach(x => context.Errors.Add(x));
                Properties.ToList().ForEach(x => context.Properties[x.Key] = x.Value);
            }

            public OperationResult()
            {
                Errors = new List<Exception>();
                Properties = new Dictionary<string, object>();
            }

            public static OperationResult Succeed => new OperationResult();

            public static OperationResult Fail(Exception error)
                => new OperationResult {
                    Errors = new List<Exception>() { error },
                    Properties = new Dictionary<string, object>() {
                        ["error"] = error.Message
                    }
                };
        }

        public static Operation<OperationResult> OperationQuery =>
            from r1 in DomainService.DoSomething(null)
            where r1.Succeeded
            select r1;

        public class DomainService
        {
            public static Operation<OperationResult> DoSomething(object arg)
            {
                return new Operation<OperationResult>(async () => {
                    await Task.Delay(200);
                    if (arg == null)
                    {
                        var error = new ArgumentException("wrong argument");
                        return OperationResult.Fail(error);
                    }
                    return OperationResult.Succeed;
                });
            }

            public static Operation<OperationResult> DoSomething()
            {
                return new Operation<OperationResult>(async () => {
                    await Task.Delay(1500);
                    return OperationResult.Succeed;
                });
            }
        }

        public static async Task MeasureOperationAsync<T>(Func<Operation<T>> factory)
            where T : IOperationContext, new()
        {
            var swBldt = new Stopwatch();
            var swExec = new Stopwatch();

            Console.WriteLine($"Measuring Operation");
            Console.WriteLine("Building ...");
            swBldt.Start();
            var operation = factory();
            swBldt.Stop();

            Console.WriteLine("Executing ...");
            swExec.Start();
            var value = await operation;
            swExec.Stop();

            var valueDisplay = operation.HasValue ? operation.Value.ToString() : "<NoValue>";
            Console.WriteLine($"Result: {valueDisplay}");
            Console.WriteLine($"Succeeded: {value.Succeeded}");
            Console.WriteLine($"Build time {swBldt.ElapsedMilliseconds}");
            Console.WriteLine($"Exctn time {swExec.ElapsedMilliseconds}");
            Console.WriteLine($"Total time {swExec.ElapsedMilliseconds + swBldt.ElapsedMilliseconds}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static async Task Run()
        {
            await MeasureOperationAsync<OperationResult>(() => OperationQuery);
        }
    }

    public class Operation<T> where T : IOperationContext, new()
    {
        private readonly Lazy<bool> has;
        private readonly LazyAsync<T> lazyAsync;

        public bool HasPredicate => (has != null);
        public bool HasValue => HasPredicate ? has.Value : true;
        public T Value => lazyAsync.Value;
        public TaskAwaiter<T> GetAwaiter() => lazyAsync.GetAwaiter();

        public Operation(Func<Task<T>> valueFactory)
        {
            this.lazyAsync = new LazyAsync<T>(valueFactory);
        }

        private Operation(Func<Task<T>> valueFactory, Func<bool> hasValue)
        {
            has = new Lazy<bool>(hasValue);
            lazyAsync = new LazyAsync<T>(valueFactory);
        }

        private U Pass<U>(T source, U target) where U : IOperationContext
        {
            if (!Object.ReferenceEquals(source, target))
            {
                source.PassTo(target);
            }
            return target;
        }

        private Task<U> BuildValueWith<U>(Func<T, U> selector, Func<T, bool> predicate)
            where U : IOperationContext, new()
            => predicate(Value) ?
                Task.Run(() => Pass(Value, selector(Value))) :
                Task.FromResult(Pass(Value, new U()));

        private Operation<U> SelectWhere<U>(Func<T, U> selector, Func<T, bool> predicate)
            where U : IOperationContext, new()
            => new Operation<U>(
                () => BuildValueWith(selector, predicate),
                () => HasValue && predicate(Value));

        public Operation<U> Select<U>(Func<T, U> selector)
            where U : IOperationContext, new()
            => SelectWhere<U>(selector, x => true);

        public Operation<T> Where(Func<T, bool> predicate)
            => SelectWhere<T>(x => x, predicate);

        public Operation<U> SelectMany<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            where U : IOperationContext, new()
            where V : IOperationContext, new()
            => Select(Compose(selector, resultSelector));

        private Func<T, U> Compose<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);
    }
}