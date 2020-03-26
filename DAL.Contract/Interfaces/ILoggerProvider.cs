using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Contract
{
    public interface ILoggerProvider<T> : IDisposable
    {
        T CreateLogger(string categoryName);

        void Dispose();
    }
}
