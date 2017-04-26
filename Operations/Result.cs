using System;
using System.Collections.Generic;

namespace Operations
{
    public static class Result
    {
        public static IResult<T> Just<T>(T value, Dictionary<string, object> props = null)
            => new Result<T>(value, props);

        public static IResult<T> None<T>(Exception error, Dictionary<string, object> props = null)
            => new Result<T>(error, props);

        public static IResult<T> None<T>(string error, Dictionary<string, object> props = null)
            => new Result<T>(new Exception(error), props);

        public static IResult<T> None<T>()
            => new Result<T>(null);

        public static IResult<T> None<U, T>(IResult<U> source)
            => new Result<T>(source.Error, source.Properties);
    }

    public sealed class Result<T> : IResult<T>
    {
        public T Value { get; }
        public bool HasValue { get; }
        public Dictionary<string, object> Properties { get; }
        public Exception Error { get; }

        internal Result()
        {
            Value = default(T);
            HasValue = false;
            Properties = GetProperties();
        }

        internal Result(T value, Dictionary<string, object> props = null)
        {
            HasValue = !EqualityComparer<T>.Default.Equals(value, default(T));
            if (!HasValue)
            {
                throw new ArgumentException(nameof(value));
            }

            Value = value;
            Properties = GetProperties(props);
        }

        internal Result(Exception error, Dictionary<string, object> props = null)
        {
            Value = default(T);
            HasValue = false;
            Error = error;
            Properties = GetProperties(props);
        }

        private Dictionary<string, object> GetProperties(
            Dictionary<string, object> props = null)
            => props == null ?
                new Dictionary<string, object>() :
                new Dictionary<string, object>(props);
    }
}