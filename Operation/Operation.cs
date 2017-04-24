using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public sealed class Operation<T>
    {
        private readonly LazyAsync<Result<T>> valueFactory;
        private T value => valueFactory.Result.Value;
        private Result<T> result => valueFactory.Value.Result;
        private Task<Result<T>> resultAsync => valueFactory.Value;
        private bool HasValue => result.HasValue;

        public Operation(Func<Task<Result<T>>> valueFactory)
        {
            this.valueFactory = new LazyAsync<Result<T>>(valueFactory);
        }

        public TaskAwaiter<Result<T>> GetAwaiter()
            => resultAsync.GetAwaiter();

        public Operation<T> Where(Func<T, bool> predicate)
            => new Operation<T>(() => HasValue && predicate(value) ?
                resultAsync : None<T>(result));

        public Operation<U> Select<U>(Func<T, U> selector)
            => new Operation<U>(() => HasValue ?
                Just(selector(value)) : None<U>(result));

        public Operation<U> SelectMany<V, U>(
            Func<T, Operation<V>> selector,
            Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        public Operation<U> Bind<U>(Func<T, Operation<U>> selector)
            => new Operation<U>(() => HasValue ?
                selector(value).resultAsync : None<U>(result));

        private Func<T, U> Compose<V, U>(
            Func<T, Operation<V>> selector,
            Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).value);

        private Task<Result<U>> None<U>(Result<T> source)
            => Task.FromResult(Result.None<T, U>(source));

        private Task<Result<U>> Just<U>(U value)
            => Task.Run(() => Result.Just(value));
    }

    public static class Operation
    {
        public static Operation<T> Get<T>(Func<Task<Result<T>>> valueFactory)
            => new Operation<T>(valueFactory);

        public static Operation<T> Get<T>(Func<Task<T>> valueFactory)
            => Get<T>(() => Task.Run(() => Result.Just(valueFactory().Result)));

        public static Operation<T> Get<T>(Func<T> value)
            => Get<T>(() => Task.FromResult(Result.Just(value())));

        public static Operation<T> None<T>()
            => Get<T>(() => Task.FromResult(Result.None<T>()));
    }
}