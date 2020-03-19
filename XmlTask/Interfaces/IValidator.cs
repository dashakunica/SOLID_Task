using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask.Interfaces
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}
