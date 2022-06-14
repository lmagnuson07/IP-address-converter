using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_Address_Converter
{
    public static class Utilities
    {
        public static bool IsBinary(char value)
        {
            bool bValid = true;
            if (value != '1' && value != '0')
            {
                bValid = false;
            }
            return bValid;
        }
    }
}
