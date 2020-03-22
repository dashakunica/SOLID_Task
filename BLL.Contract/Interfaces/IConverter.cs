using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Contract
{
    public interface IConverter<in TSource, out TResult>
    {
        IEnumerable<TResult> Convert(IEnumerable<TSource> source);
    }
}
