using System;
using System.Collections.Generic;
using System.Text;
using Bll.Contract;

namespace BLL.Implementaion2
{
    public class Validator : IValidator<string>
    {
        public bool IsValid(string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            string[] splitSource = value.Split(',');
            bool isValid;
            isValid = splitSource[0].Length == 6;

            return isValid;
        }
    }
}
