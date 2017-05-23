namespace Operations
{
    public interface IPreBuilder<T, TSelf> : IOperationPreBuilder<T>
    {
        TSelf Return(IOperationService<T> source);
    }
}