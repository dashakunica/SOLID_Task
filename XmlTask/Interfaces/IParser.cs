using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask.Interfaces
{
    public interface IParser<TSource, TResult>
    {
        TResult Parse(TSource source);
    }
}
