using System;

namespace Operations
{
    public interface IMapping<T>
    {
        IOperation<T> Map(IOperation<T> arg);
    }

    internal class Mapping<T> : IMapping<T>
    {
        private readonly Func<IOperation<T>, IOperation<T>> mapping;

        public Mapping(Func<IOperation<T>, IOperation<T>> mapping)
            => this.mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));

        public IOperation<T> Map(IOperation<T> arg)
            => mapping(arg);
    }
}