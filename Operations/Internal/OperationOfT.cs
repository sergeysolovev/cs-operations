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
}