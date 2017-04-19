using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public class Operation<T>
    {
        private readonly Lazy<Task<T>> lazyAsync;

        public Task<T> Value => lazyAsync.Value;
        public T Result => Value.Result;
        public TaskAwaiter<T> GetAwaiter() => Value.GetAwaiter();

        public Operation(Func<T> valueFactory) : this(() => Task.Run(valueFactory)) {}

        public Operation(Func<Task<T>> valueFactory)
        {
            if (valueFactory == null)
            {
                throw new ArgumentNullException(nameof(valueFactory));
            }

            lazyAsync = new Lazy<Task<T>>(valueFactory);
        }
    }

    static class OperationExtensions
    {
        public static Operation<TResult> SelectMany<TSource, TNext, TResult>(
            this Operation<TSource> source,
            Func<TSource, Operation<TNext>> selector,
            Func<TSource, TNext, TResult> resultSelector)
            => Bind(source, s => Bind(selector(s), Async((TNext n) => resultSelector(s, n))));

        public static Operation<TResult> Select<TSource, TResult>(
            this Operation<TSource> source,
            Func<TSource, TResult> selector)
            => Bind(source, Async(selector));

        public static Operation<TResult> Where<TResult>(this Func<TResult, bool> predicate)
        {
            
        }

        private static Operation<TResult> Bind<TSource, TResult>(
            this Operation<TSource> source,
            Func<TSource, Operation<TResult>> selector)
            => Unit(() => selector(source.Result).Value);

        private static Func<T, Operation<U>> Async<T, U>(Func<T, U> selector)
            => x => Unit(() => Task.Run(() => selector(x)));

        private static Operation<T> Unit<T>(Func<Task<T>> valueFactory)
            => new Operation<T>(valueFactory);
    }
}
