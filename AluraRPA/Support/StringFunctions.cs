using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AluraRPA.Support
{
    internal class StringFunctions
    {
        public int returnIntFromChain(string chain)
        {
            Regex rgx = new Regex("[^0-9]");
            chain = rgx.Replace(chain, "");
            int returnInt = 0;

            string s1 = Regex.Replace(chain, "[^0-9]", "");
            returnInt += Int32.Parse(chain);
            return returnInt;
        }
    }
}
