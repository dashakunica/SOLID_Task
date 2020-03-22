using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contract
{
    public interface IProvider<out T>
    {
        IEnumerable<T> GetData();
    }
}
