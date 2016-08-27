using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAsynchronousTask
{
    /// <summary>
    /// Wraps an exception to know when it happens in an async method.
    /// </summary>
    /// <typeparam name="TException">Any type of exception.</typeparam>
    class AsyncException<TException>
    {
        public TException Error { get; set; }
        public bool WasRaised { get; set; }
    }
}
