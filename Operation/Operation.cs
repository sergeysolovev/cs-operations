using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public sealed class Operation<T>
    {
        private readonly LazyAsync<Result<T>> valueFactory;

        private Task<Result<T>> ResultAsync => valueFactory.Value;
        private bool HasValue               => ResultAsync.Result.HasValue;
        private T Value                     => valueFactory.Result.Value;

        public Operation(Func<Task<Result<T>>> valueFactory)
        {
            this.valueFactory = new LazyAsync<Result<T>>(valueFactory);
        }

        public Operation(Func<Task<T>> valueFactory)
            : this(() => ContinueWith(valueFactory()))
        {
        }

        public TaskAwaiter<Result<T>> GetAwaiter()
            => ResultAsync.GetAwaiter();

        public Operation<T> Where(Func<T, bool> predicate)
            => new Operation<T>(() => HasValue && predicate(Value) ?
                ResultAsync : ContinueWithNone<T>(ResultAsync));

        public Operation<U> Select<U>(Func<T, U> selector)
            => new Operation<U>(() => HasValue ?
                ContinueWith<U>(ResultAsync, selector) :
                ContinueWithNone<U>(ResultAsync));

        public Operation<U> SelectMany<V, U>(
            Func<T, Operation<V>> selector,
            Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        public Operation<U> Bind<U>(Func<T, Operation<U>> selector)
            => Select(x => selector(x).Value);

        private Func<T, U> Compose<V, U>(
            Func<T, Operation<V>> selector,
            Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);

        private Task<Result<U>> ContinueWithNone<U>(
            Task<Result<T>> source)
            => source.ContinueWith(x => Result.None<T, U>(source.Result));

        private Task<Result<U>> ContinueWith<U>(
            Task<Result<T>> source,
            Func<T, U> selector)
            => source.ContinueWith(x => Result.Just<U>(selector(x.Result.Value)));

        private static Task<Result<T>> ContinueWith(Task<T> source)
            => source.ContinueWith(x => Result.Just<T>(source.Result));
    }

    public static class Operation
    {
        public static Operation<T> Get<T>(Func<Task<Result<T>>> valueFactory)
            => new Operation<T>(valueFactory);

        public static Operation<T> Get<T>(Func<Task<T>> valueFactory)
            => new Operation<T>(valueFactory);

        public static Operation<T> None<T>()
            => Get<T>(() => Task.FromResult(Result.None<T>()));

        // todo: only for testing purposes
        public static Operation<T> Get<T>(Func<T> value)
            => Get<T>(() => Task.Run(() => Result.Just(value())));
    }
}