using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common
{
    public static class SecuritySupport
    {
        public static string ClearnForSqlInjection(string data)
        {
            //-- we need to clean supplier name for injection
            string retVal = data.Replace("'", "''");

            //-- replace terminator key with empty string.
            retVal = data.Replace(";", String.Empty);

            //-- replace comment with empty string
            retVal = data.Replace("--", String.Empty);

            return retVal;
        }

    }
}
