using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contract
{
    public interface IPersister<T>
    {
        void Save(IEnumerable<T> source);
    }
}
