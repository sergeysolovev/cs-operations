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

    public class Zx<T>
    {
        private readonly LazyAsync<Result<T>> valueFactory;
        private T Value => valueFactory.Result.Value;
        private Result<T> Result => valueFactory.Value.Result;
        private Task<Result<T>> ResultAsync => valueFactory.Value;
        private bool HasValue => Result.HasValue;
        public TaskAwaiter<Result<T>> GetAwaiter() => ResultAsync.GetAwaiter();

        public Zx(Func<Task<Result<T>>> valueFactory)
        {
            this.valueFactory = new LazyAsync<Result<T>>(valueFactory);
        }

        public Zx<T> Where(Func<T, bool> predicate)
            => new Zx<T>(() => HasValue && predicate(Value) ? ResultAsync : None<T>(Result));

        public Zx<U> Select<U>(Func<T, U> selector)
            => new Zx<U>(() => HasValue ? Just(selector(Value)) : None<U>(Result));

        public Zx<U> ProceedWith<U>(Func<T, Zx<U>> selector)
            => new Zx<U>(() => HasValue ? selector(Value).ResultAsync : None<U>(Result));

        public Zx<U> SelectMany<V, U>(Func<T, Zx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        private Func<T, U> Compose<V, U>( Func<T, Zx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);

        private Task<Result<U>> None<U>(Result<T> source)
            => Task.FromResult(Operations.Result.None<T, U>(source));

        private Task<Result<U>> Just<U>(U value)
            => Task.Run(() => Operations.Result.Just(value));
    }
}