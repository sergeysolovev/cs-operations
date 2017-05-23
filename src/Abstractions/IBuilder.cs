using System;
using System.Threading.Tasks;

namespace Operations
{
    public interface IBuilder<T, TSelf> : IOperationBuilder<T>
    {
        TSelf Return(IOperation<T> source);
    }
}