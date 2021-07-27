using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.Utilities.Convertor
{
    public class FixedText
    {
        public static string FixEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
