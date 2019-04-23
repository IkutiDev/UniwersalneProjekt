using System;
using System.Collections.Generic;
using System.Text;

namespace UniwersalneProjekt.Validators
{
    public static class ValidatorRule
    {
        public static bool IsNotNullOrEmpty(string value)
        {
            if(value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
