using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    internal class Operation<T> : IOperation<T>
    {
        private readonly Lazy<Task<IResult<T>>> valueFactory;

        public Task<IResult<T>> ExecuteAsync() => valueFactory.Value;

        public Operation(Func<Task<IResult<T>>> valueFactory)
            => this.valueFactory = new Lazy<Task<IResult<T>>>(valueFactory);
    }

    public static class Operation
    {
        public static IOperation<T> Get<T>(Func<Task<IResult<T>>> valueFactory)
            => new Operation<T>(valueFactory);

        public static IOperation<T> Get<T>(Func<IResult<T>> valueFactory)
            => new Operation<T>(() => Task.Run(valueFactory));

        public static IOperation<T> Get<T>(Func<Task<T>> valueFactory)
            => new Operation<T>(() => Wrap(valueFactory()));

        public static IOperation<T> Get<T>(Func<T> value)
            => Get<T>(() => Task.FromResult(Result.Just(value())));

        public static IOperation<T> None<T>()
            => Get<T>(() => Task.FromResult(Result.None<T>()));

        private static Task<IResult<T>> Wrap<T>(Task<T> source)
            => source.ContinueWith(x => Result.Just<T>(source.Result));
    }
}