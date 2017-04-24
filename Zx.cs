using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public static class Zx
    {
        public static Zx<T> Get<T>(Func<Task<Result<T>>> valueFactory)
            => new Zx<T>(valueFactory);

        public static Zx<T> Get<T>(Func<T> value)
            => Get<T>(() => Task.FromResult(Result.Just(value())));
    }

    public sealed class Zx<T>
    {
        private readonly LazyAsync<Result<T>> valueFactory;
        private T value => valueFactory.Result.Value;
        private Result<T> result => valueFactory.Value.Result;
        private Task<Result<T>> resultAsync => valueFactory.Value;
        private bool HasValue => result.HasValue;
        public TaskAwaiter<Result<T>> GetAwaiter() => resultAsync.GetAwaiter();

        public Zx(Func<Task<Result<T>>> valueFactory)
        {
            this.valueFactory = new LazyAsync<Result<T>>(valueFactory);
        }

        public Zx<T> Where(Func<T, bool> predicate)
            => new Zx<T>(() => HasValue && predicate(value) ? resultAsync : None<T>(result));

        public Zx<U> Select<U>(Func<T, U> selector)
            => new Zx<U>(() => HasValue ? Just(selector(value)) : None<U>(result));

        public Zx<U> SelectMany<V, U>(Func<T, Zx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        public Zx<U> Bind<U>(Func<T, Zx<U>> selector)
            => new Zx<U>(() => HasValue ? selector(value).resultAsync : None<U>(result));

        private Func<T, U> Compose<V, U>( Func<T, Zx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).value);

        private Task<Result<U>> None<U>(Result<T> source)
            => Task.FromResult(Operations.Result.None<T, U>(source));

        private Task<Result<U>> Just<U>(U value)
            => Task.Run(() => Operations.Result.Just(value));
    }
}