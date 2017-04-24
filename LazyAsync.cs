using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    // Async:       + necessary
    // Zero:        - necessary
    // Id:          - good but not necessary, also good for DI
    // Deferred:    + good but not necessary
    // Unit:        - good but necessary
    public class LazyAsync<T>
    {
        private readonly Lazy<Task<T>> source;

        public T Result                     => source.Value.Result;
        public Task<T> Value                => source.Value;
        public TaskAwaiter<T> GetAwaiter()  => source.Value.GetAwaiter();

        public LazyAsync(Func<T> valueFactory) :
            this(() => Task.Run(valueFactory))
        {
        }

        public LazyAsync(Func<Task<T>> valueFactory)
        {
            source = new Lazy<Task<T>>(valueFactory);
        }

        public LazyAsync<TResult> SelectMany<TNext, TResult>(
            Func<T, LazyAsync<TNext>> selector,
            Func<T, TNext, TResult> resultSelector)
            => Select(Compose(selector, resultSelector));

        public LazyAsync<TResult> Select<TResult>(
            Func<T, TResult> selector)
            => new LazyAsync<TResult>(() => selector(Result));

        public LazyAsync<TResult> Bind<TResult>(
            Func<T, LazyAsync<TResult>> selector)
            => new LazyAsync<TResult>(() => selector(Result).Result);

        private Func<T, TResult> Compose<TNext, TResult>(
            Func<T, LazyAsync<TNext>> selector,
            Func<T, TNext, TResult> resultSelector)
            => x => resultSelector(x, selector(x).Result);
    }

    static class LazyAsyncExtensions
    {
        public static LazyAsync<TResult> SelectMany<TSource, TNext, TResult>(
            this LazyAsync<TSource> source,
            Func<TSource, LazyAsync<TNext>> selector,
            Func<TSource, TNext, TResult> resultSelector)
            => Select(source, Compose(selector, resultSelector));

        public static Func<TSource, TResult> Compose<TSource, TNext, TResult>(
            Func<TSource, LazyAsync<TNext>> selector,
            Func<TSource, TNext, TResult> resultSelector)
            => x => resultSelector(x, selector(x).Result);

        public static LazyAsync<TResult> Select<TSource, TResult>(
            this LazyAsync<TSource> source,
            Func<TSource, TResult> selector)
            => new LazyAsync<TResult>(() => selector(source.Result));

        private static LazyAsync<TResult> Bind<TSource, TResult>(
            this LazyAsync<TSource> source,
            Func<TSource, LazyAsync<TResult>> selector)
            => new LazyAsync<TResult>(() => selector(source.Result).Result);
    }
}
