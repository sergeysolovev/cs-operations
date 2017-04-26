using System;

namespace Operations
{
    public class OperationException : Exception
    {
        public OperationException(string message) => new Exception(message);
    }
}