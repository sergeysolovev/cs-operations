using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Operations.Linq
{
    public static class Operation
    {
        public static IOperation<T> Get<T>(Func<Task<IResult<T>>> valueFactory)
            => new Operation<T>(valueFactory);

        public static IOperation<T> Get<T>(Func<ValueTask<IResult<T>>> valueFactory)
            => new ValueOperation<T>(valueFactory);

        public static IOperation<T> Get<T>(Func<IResult<T>> valueFactory)
            => new ValueOperation<T>(() => new ValueTask<IResult<T>>(valueFactory()));

        public static IOperation<T> Get<T>(Func<Task<T>> valueFactory)
            => new Operation<T>(() => Wrap(valueFactory()));

        public static IOperation<T> Get<T>(Func<T> valueFactory)
            => Get<T>(() => Result.Just(valueFactory()));

        public static IOperation<T> Get<T>(T value)
            => Get<T>(() => Result.Just(value));

        public static IOperation<T> None<T>()
            => Get<T>(() => Result.None<T>());

        private static Task<IResult<T>> Wrap<T>(Task<T> source)
            => source.ContinueWith(x => Result.Just<T>(source.Result));

        public static IOperation<T> Where<T>(
            this IOperation<T> self,
            Func<T, bool> predicate)
            => new Operation<T>(
                () => HasValue(self) && predicate(GetValue(self)) ?
                    ExecuteAsync(self) :
                    ContinueWithNone<T, T>(ExecuteAsync(self)));

        public static IOperation<U> Select<T, U>(
            this IOperation<T> self,
            Func<T, U> selector)
            => new Operation<U>(() => HasValue(self) ?
                Continue(ExecuteAsync(self), selector) :
                ContinueWithNone<T, U>(ExecuteAsync(self)));

        public static IOperation<U> SelectMany<T, V, U>(
            this IOperation<T> self,
            Func<T, IOperation<V>> selector,
            Func<T, V, U> resultSelector)
            => Select(self, Compose(selector, resultSelector));

        private static Func<T, U> Compose<T, V, U>(
            Func<T, IOperation<V>> selector,
            Func<T, V, U> resultSelector)
            => x => resultSelector(x, GetValue(selector(x)));

        private static Task<IResult<U>> ContinueWithNone<T, U>(
            Task<IResult<T>> source)
            => source.ContinueWith(x => Result.None<T, U>(source.Result));

        private static Task<IResult<U>> Continue<T, U>(
            Task<IResult<T>> source,
            Func<T, U> selector)
            => source.ContinueWith(x => Result.Just<U>(selector(x.Result.Value)));

        private static bool HasValue<T>(this IOperation<T> self)
            => ExecuteAsync(self).Result.HasValue;

        public static T GetValue<T>(this IOperation<T> self)
            => ExecuteAsync(self).Result.Value;

        private static Task<IResult<T>> ExecuteAsync<T>(this IOperation<T> self)
            => self.ExecuteAsync();
    }
}