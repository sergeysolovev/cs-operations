using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations
{
    internal class Operation<T> : IOperation<T>
    {
        private readonly Func<Task<IResult<T>>> valueFactory;

        public Task<IResult<T>> ExecuteAsync() => valueFactory();

        public Operation(Func<Task<IResult<T>>> valueFactory) => this.valueFactory =
            valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));

    }
}