using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;

namespace Operations
{
    public static class Operation
    {
        public static Operation<T> Get<T>(Func<Task<T>> valueFactory)
            where T : IAssignable
            => new Operation<T>(valueFactory);
    }

    public class Operation<TSource> where TSource : IAssignable
    {
        private readonly LazyAsync<TSource> operation;
        private readonly Lazy<bool> isNull;

        private TSource Result      => operation.Result;
        private Task<TSource> Value => operation.Value;
        private bool IsNotNull      => !isNull.Value;

        public TaskAwaiter<TSource> GetAwaiter() => Value.GetAwaiter();

        public Operation(Func<Task<TSource>> valueFactory)
            : this(valueFactory, Id)
        {}

        private Operation(
            Func<Task<TSource>> valueFactory,
            Func<Task<TSource>, Task<TSource>> operation)
        {
            this.isNull = new Lazy<bool>(
                valueFactory: () => operation(valueFactory()) == null);
            this.operation = new LazyAsync<TSource>(
                valueFactory: () => IsNotNull ? operation(valueFactory()) : valueFactory());
        }

        public Operation<TSource> Where(Func<TSource, bool> predicate)
            => new Operation<TSource>(
                () => Value,
                xr => IsNotNull && predicate(Result) ? xr : null);

        public Operation<TResult> Select<TResult>(Func<TSource, TResult> selector)
            where TResult : IAssignable, new()
            => new Operation<TResult>(
                () => IsNotNull ? New<TResult>() : NewFrom<TResult>(Result),
                xr => IsNotNull ? Task.Run(() => selector(Result)) : xr);

        public Operation<TResult> ProceedWith<TResult>(Func<TSource, Operation<TResult>> selector)
            where TResult : IAssignable, new()
            => new Operation<TResult>(
                () => IsNotNull ? New<TResult>() : NewFrom<TResult>(Result),
                xr => IsNotNull ? selector(Result).Value : xr);

        public Operation<TResult> SelectMany<TNext, TResult>(
            Func<TSource, Operation<TNext>> selector,
            Func<TSource, TNext, TResult> resultSelector)
            where TResult : IAssignable, new()
            where TNext : IAssignable
            => Select(Compose(selector, resultSelector));

        private Func<TSource, TResult> Compose<TNext, TResult>(
            Func<TSource, Operation<TNext>> selector,
            Func<TSource, TNext, TResult> resultSelector)
            where TResult : IAssignable
            where TNext : IAssignable
            => x => resultSelector(x, selector(x).Result);

        private static Func<Task<TSource>, Task<TSource>> Id = x => x;

        private Task<TResult> New<TResult>()
            where TResult : IAssignable, new()
            => Task.FromResult(new TResult());

        private Task<TResult> NewFrom<TResult>(TSource source)
            where TResult : IAssignable, new()
        {
            var value = new TResult();
            value.AssignFrom(source);
            return Task.FromResult(value);
        }
    }
}