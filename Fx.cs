using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public class Fx<T>
    {
        private readonly LazyAsync<Result<T>> lazyAsync;
        private Task<Result<T>> ValueAsync => lazyAsync.Value;
        public bool Succeeded => Value.Succeeded;
        public T Result => Value.Value;
        public Result<T> Value => ValueAsync.Result;
        public TaskAwaiter<Result<T>> GetAwaiter() => ValueAsync.GetAwaiter();

        public Fx(Func<Task<Result<T>>> valueFactory)
        {
            lazyAsync = new LazyAsync<Result<T>>(valueFactory);
        }

        public Fx(Func<Result<T>> valueFactory)
        {
            lazyAsync = new LazyAsync<Result<T>>(valueFactory);
        }

        public Fx(Func<T> valueFactory) :
            this(ValueFactory(valueFactory()))
        {}

        public Fx(Func<Task<T>> valueFactory) :
            this(ValueFactory(valueFactory().Result))
        {}

        private static Func<Task<Result<T>>> ValueFactory(T value)
            => () => Task.Run(() => new Result<T>(value));

        public Fx<U> Select<U>(Func<T, U> selector)
            => SelectWhere(x => Succeeded, selector);

        public Fx<T> Where(Func<T, bool> predicate)
            => SelectWhere(predicate, id);

        public Fx<U> SelectMany<V, U>(Func<T, Fx<V>> selector, Func<T, V, U> resultSelector)
            => Select(Compose(selector, resultSelector));

        private Fx<U> SelectWhere<U>(Func<T, bool> predicate, Func<T, U> selector)
            => new Fx<U>(() => predicate(Result) ?
                new Result<U>(selector(Result)) :
                Result<U>.None);

        private Func<T, U> Compose<V, U>(Func<T, Fx<V>> selector, Func<T, V, U> resultSelector)
            => x => resultSelector(x, selector(x).Result);

        private Func<T, T> id = x => x;
    }

    public class Result<T>
    {
        public T Value { get; }
        public bool Succeeded { get; private set; }
        public static Result<T> None => new Result<T>();
        private Result() {}
        public Result(T value) { Value = value; Succeeded = true; }
    }
}