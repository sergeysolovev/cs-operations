namespace Operations
{
    internal class OperationBuilder<T> : IOperationBuilder<T>
    {
        private readonly IOperation<T> source;

        internal OperationBuilder(IOperation<T> source)
            => this.source = Throw.IfNull(source, nameof(source));

        public IOperation<T> Build()
            => source;
    }
}