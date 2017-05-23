namespace Operations
{
    public interface IOperationPreBuilder<T>
    {
        IOperationBuilder<T> Inject(T injection);
    }
}