using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMO.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (value == null) return string.Empty;

            if (value.Length <= maxLength) return value;

            var result = value.Substring(0, maxLength);
            return $"{result} ...";
        }
    }
}
