using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public class LazyAsyncMaybe<T>
    {
        private readonly LazyAsync<Maybe<T>> source;

        public bool HasValue                        => Result.HasValue;
        public T Value                              => Result.Value;
        public Maybe<T> Result                      => source.Result;
        public TaskAwaiter<Maybe<T>> GetAwaiter()   => source.GetAwaiter();

        public LazyAsyncMaybe(Func<Maybe<T>> valueFactory)
            : this(Convert(valueFactory))
        {}

        public LazyAsyncMaybe(Func<Task<T>> valueFactory)
            : this(Convert(valueFactory))
        {}

        public LazyAsyncMaybe(Func<T> valueFactory)
            : this(Convert(valueFactory))
        {}

        public LazyAsyncMaybe(Func<Task<Maybe<T>>> valueFactory)
        {
            source = new LazyAsync<Maybe<T>>(valueFactory);
        }

        private static Func<Task<Maybe<T>>> Convert(Func<Task<T>> valueFactory)
            => () => Task.Run(() => Maybe<T>.Just(valueFactory().Result));

        private static Func<Task<Maybe<T>>> Convert(Func<T> valueFactory)
            => () => Task.Run(() => Maybe<T>.Just(valueFactory()));

        private static Func<Task<Maybe<T>>> Convert(Func<Maybe<T>> valueFactory)
            => () => Task.Run(valueFactory);
    }

    public class Maybe<T>
    {
        public T Value { get; }
        public bool HasValue { get; private set; }
        public static Maybe<T> Just(T value) => new Maybe<T>(value);
        public static Maybe<T> NoValue => new Maybe<T>();
        private Maybe() {}
        private Maybe(T value) { Value = value; HasValue = true; }
        public override string ToString() => HasValue ? Value.ToString() : "<NoValue>";
    }

    public class Fx<T>
    {
        private readonly LazyAsyncMaybe<T> source;

        private bool HasValue                       => source.HasValue;
        private T Value                             => source.Value;
        public Maybe<T> Result                      => source.Result;
        public TaskAwaiter<Maybe<T>> GetAwaiter()   => source.GetAwaiter();

        public Fx(Func<Task<T>> valueFactory)
        {
            source = new LazyAsyncMaybe<T>(valueFactory);
        }

        public Fx(Func<T> valueFactory)
        {
            source = new LazyAsyncMaybe<T>(valueFactory);
        }

        private Fx(Func<Maybe<T>> valueFactory)
        {
            source = new LazyAsyncMaybe<T>(valueFactory);
        }

        public Fx<U> SelectMany<V, U>(Func<T, Fx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        public Fx<U> Select<U>(Func<T, U> selector)
            => SelectWhere(selector, x => true);

        public Fx<T> Where(Func<T, bool> predicate)
            => SelectWhere(x => x, predicate);

        private Fx<U> SelectWhere<U>(Func<T, U> selector, Func<T, bool> predicate)
            => new Fx<U>(() => (HasValue && predicate(Value)) ?
                Maybe<U>.Just(selector(Value)) :
                Maybe<U>.NoValue);

        private Func<T, U> Compose<V, U>(Func<T, Fx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Value);
    }
}