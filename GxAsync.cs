using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public class GxAsync<T>
    {
        private Lazy<bool> has;
        private LazyAsync<T> lazyAsync;
        public bool HasPredicate => (has != null);
        public bool HasValue => HasPredicate ? has.Value : true;
        public T Value => lazyAsync.Value;
        public TaskAwaiter<T> GetAwaiter() => lazyAsync.GetAwaiter();

        public GxAsync(Func<Task<T>> valueFactory)
        {
            lazyAsync = new LazyAsync<T>(valueFactory);
        }

        private GxAsync(Func<Task<T>> valueFactory, Func<bool> hasValue)
        {
            has = new Lazy<bool>(hasValue);
            lazyAsync = new LazyAsync<T>(() => has.Value ?
                valueFactory() :
                Task.FromResult(default(T)));
        }

        public GxAsync<U> Select<U>(Func<T, U> selector)
            => HasPredicate ?
                new GxAsync<U>(() => Task.Run(() => selector(Value)), () => HasValue) :
                new GxAsync<U>(() => Task.Run(() => selector(Value)));

        public GxAsync<T> Where(Func<T, bool> predicate)
            => new GxAsync<T>(() => Task.Run(() => Value), () => HasValue && predicate(Value));

        public GxAsync<U> SelectMany<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        private Func<T, U> Compose<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);
    }
}