using System;

namespace Operations
{
    public class Gx<T>
    {
        private Lazy<bool> has;
        private Lazy<T> lazy;
        public bool HasPredicate => (has != null);
        public bool HasValue => HasPredicate ? has.Value : true;
        public T Value => lazy.Value;

        public Gx(Func<T> valueFactory)
        {
            lazy = new Lazy<T>(valueFactory);
        }

        private Gx(Func<T> valueFactory, Func<bool> hasValue)
        {
            has = new Lazy<bool>(hasValue);
            lazy = new Lazy<T>(() => has.Value ?
                valueFactory() :
                default(T));
        }

        public Gx<U> Select<U>(Func<T, U> selector)
            => HasPredicate ?
                new Gx<U>(() => selector(Value), () => HasValue) :
                new Gx<U>(() => selector(Value));

        public Gx<T> Where(Func<T, bool> predicate)
            => new Gx<T>(() => Value, () => HasValue && predicate(Value));

        public Gx<U> SelectMany<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        private Func<T, U> Compose<V, U>(Func<T, Gx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);
    }
}