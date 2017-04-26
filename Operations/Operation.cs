using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    public static class Operation
    {
        public static IOperation<T> Get<T>(Func<Task<IResult<T>>> valueFactory)
            => new Operation<T>(valueFactory);

        public static IOperation<T> Get<T>(Func<ValueTask<IResult<T>>> valueFactory)
            => new ValueOperation<T>(valueFactory);

        public static IOperation<T> Get<T>(Func<IResult<T>> valueFactory)
            => new ValueOperation<T>(() => new ValueTask<IResult<T>>(valueFactory()));

        public static IOperation<T> Get<T>(Func<Task<T>> valueFactory)
            => new Operation<T>(() => Wrap(valueFactory()));

        public static IOperation<T> Get<T>(Func<T> valueFactory)
            => Get<T>(() => Result.Just(valueFactory()));

        public static IOperation<T> Get<T>(T value)
            => Get<T>(() => Result.Just(value));

        public static IOperation<T> None<T>()
            => Get<T>(() => Result.None<T>());

        private static Task<IResult<T>> Wrap<T>(Task<T> source)
            => source.ContinueWith(x => Result.Just<T>(source.Result));
    }
}