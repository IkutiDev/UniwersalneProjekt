using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public static bool IsOnlyPlainText(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z .!?:()]+$");
        }
        public static bool IsNumbersOnly(string value)
        {
            return value.Any(char.IsDigit);
        }
        public static bool IsDateOnly(string value)
        {
            DateTime dt;
            return DateTime.TryParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out dt);
        }
        public static bool IsYearOnly(string value)
        {
            return Regex.IsMatch(value, "^(19|20|21)[0-9][0-9]");
        }
        public static bool IsNameAndSurameOnly(string value)
        {
            return Regex.IsMatch(value, @"^[A-Z][a-z]+(\s|,)[A-Z][a-z]{1,19}$");
        }
    }
}
