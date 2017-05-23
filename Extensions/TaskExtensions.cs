using System;
using System.Threading.Tasks;

namespace Operations
{
    internal static class TaskExtensions
    {
        internal static Task<T> ToTask<T>(this T value)
            => Task.FromResult(value);

        internal static async Task<U> Bind<T, U>(
            this Task<T> source,
            Func<T, Task<U>> closure)
            => await closure(await source);

        internal static async Task<U> Select<T, U>(
            this Task<T> source,
            Func<T, U> selector)
            => selector(await source);
    }
}