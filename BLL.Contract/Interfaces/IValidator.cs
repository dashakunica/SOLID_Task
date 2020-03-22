using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Contract
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}
