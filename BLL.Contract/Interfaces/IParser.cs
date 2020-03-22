using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Contract
{
    public interface IParser<TSource, TResult>
    {
        TResult Parse(TSource source);
    }
}
