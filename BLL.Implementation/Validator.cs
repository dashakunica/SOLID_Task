using System;
using System.Collections.Generic;
using System.Text;
using Bll.Contract;

namespace BLL.Implementation
{
    public class Validator : IValidator<string>
    {
        public bool IsValid(string value)
        {
            if (value is null) 
                throw new ArgumentNullException(nameof(value));

            bool isValid;
            try
            {
                var uri = new Uri(value);
                isValid = uri.IsAbsoluteUri && !uri.IsFile;
            }
            catch(Exception ex)
            {
                throw new ArithmeticException(value);
            }

            return isValid;
        }
    }
}
