using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayLightMachineController.Utility
{
    static class StringHelper
    {
        public static string RemoveNonNumbers(string s)
        {
            foreach (char c in s)
            {
                if (c - 48 > 9)
                {
                    s = s.Replace(c.ToString(), "");
                }
            }
            return s;
        }
    }
}
