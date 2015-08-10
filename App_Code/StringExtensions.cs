using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for nullvals
/// </summary>

namespace System
{
    public static class StringExtensions
    {
        public static string NullString(this string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }
    }
}