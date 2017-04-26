using System;
using System.Collections.Generic;

namespace Operations
{
    public interface IResult<out T>
    {
        T Value { get; }
        bool HasValue { get; }
        Dictionary<string, object> Properties { get; }
        Exception Error { get; }
    }
}