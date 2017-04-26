using System;
using System.Threading.Tasks;

namespace Operations
{
    internal class ValueOperation<T> : IOperation<T>
    {
        private readonly Lazy<ValueTask<IResult<T>>> valueFactory;

        public Task<IResult<T>> ExecuteAsync() => valueFactory.Value.AsTask();

        public ValueOperation(Func<ValueTask<IResult<T>>> valueFactory)
            => this.valueFactory = new Lazy<ValueTask<IResult<T>>>(valueFactory);
    }
}