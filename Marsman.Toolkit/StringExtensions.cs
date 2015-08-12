using System.Text.RegularExpressions;

namespace Marsman.Toolkit
{
    public static class StringExtensions
    {
        private static Regex _emailRegex;
        private static Regex _postcodeRegex;

        /// <summary>
        /// Determines if a string contains a valid email address
        /// </summary>
        public static bool IsValidEmailAddress(this string str)
        {
            if (_emailRegex == null)
            {
                _emailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", RegexOptions.IgnoreCase);
            }
            return _emailRegex.IsMatch(str);
        }

        /// <summary>
        /// Determines if a string contains a valid UK postcode
        /// </summary>
        public static bool IsValidPostcode(this string str)
        {
            if (_postcodeRegex == null)
            {
                _postcodeRegex = new Regex(@"^(GIR|[A-Z]\d[A-Z\d]??|[A-Z]{2}\d[A-Z\d]??)[ ]??(\d[A-Z]{2})$", RegexOptions.IgnoreCase);
            }
            return _postcodeRegex.IsMatch(str);
        }
    }
}