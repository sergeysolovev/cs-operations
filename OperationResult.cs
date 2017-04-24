using System;
using System.Collections.Generic;
using System.Linq;

namespace Operations
{
    public sealed class StringResult : OperationResult
    {
        public string Value;

        private StringResult(
            string value,
            Dictionary<string, object> properties = null) : base(true, properties)
        {
            Value = value;
        }

        private StringResult(
            Exception error,
            Dictionary<string, object> properties = null) : base(error, properties)
        {}
    }

    public class OperationResult : IAssignable
    {
        private readonly bool succeeded;
        public readonly Dictionary<string, object> Properties;
        public readonly List<Exception> Errors;
        public bool Succeeded => succeeded && !Errors.Any();

        public OperationResult()
        {
            this.Errors = new List<Exception>();
            this.Properties = new Dictionary<string, object>();
        }

        public OperationResult(
            bool succeeded,
            Dictionary<string, object> properties)
        {
            this.succeeded = succeeded;
            this.Errors = new List<Exception>();
            this.Properties = properties == null ?
                new Dictionary<string, object>() :
                new Dictionary<string, object>(properties);
        }

        public OperationResult(
            Exception error,
            Dictionary<string, object> properties) : this(false, properties)
        {
            this.Errors.Add(error);
            this.Properties = properties == null ?
                new Dictionary<string, object>() :
                new Dictionary<string, object>(properties);
        }

        public static OperationResult Succeed
            => new OperationResult(true, null);

        public static OperationResult Fail(Exception error)
            => new OperationResult(error, null);

        void IAssignable.AssignFrom(IAssignable source)
        {
            var from = source as OperationResult;
            if (from != null)
            {
                Errors.ForEach(x => from.Errors.Add(x));
                Properties.ToList().ForEach(x => from.Properties[x.Key] = x.Value);
            }
        }
    }
}