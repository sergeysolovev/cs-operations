using System;
using System.Threading.Tasks;

namespace Operations
{
    public static class Builder
    {
        public static TBuilder With<TResult, TBuilder>(
            this IBuilder<TResult, TBuilder> source,
            IOperationService<TResult> service)
            => source.Return(source.Build().Bind(service));

        public static TBuilder With<TResult, TBuilder>(
            this IBuilder<TResult, TBuilder> source,
            Func<TResult, IOperation<TResult>> closure)
            => source.Return(source.Build().Bind(closure));

        public static TBuilder With<TResult, TBuilder>(
            this IBuilder<TResult, TBuilder> source,
            Func<TResult, Task<IContext<TResult>>> closure)
            => source.Return(source.Build().Bind(closure));

        public static TBuilder With<TResult, TBuilder>(
            this IBuilder<TResult, TBuilder> source,
            Func<TResult, IContext<TResult>> closure)
            => source.Return(source.Build().Bind(closure));
    }
}