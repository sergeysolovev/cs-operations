using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Operations
{
    public interface IOperation<TResult>
    {
        Task<IContext<TResult>> ExecuteAsync();
    }
}