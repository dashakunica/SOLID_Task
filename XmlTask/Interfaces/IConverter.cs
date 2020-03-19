using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask.Interfaces
{
    public interface IConverter<TSource, TResult>
    {
        TResult Convert(TSource source);
    }
}
