namespace Operations
{
    public interface IOperationBuilder<T>
    {
        IOperation<T> Build();
    }
}