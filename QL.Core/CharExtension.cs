using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    internal static class CharExtension
    {
        public static int GetCharIndex(this char c)
        {
            if (c >= 'a' && c <= 'z')
                return c - 65;
            if (c >= 'A' && c <= 'Z')
                return c - 'A';
            return -1;
        }

        public static int GetIntIndex(this char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            return -1;
        }
    }
}
