using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
    public enum SortOrderDirection : byte
    {
        Ascending = 0,
        Descending = 1
    }

    public static class SortOrder
    {

        /// <summary>
        /// returns 1 if the value is desc or else it returns 0
        /// </summary>
        /// <param name="data">String value of sort (ASC or DESC)</param>
        /// <returns></returns>
        public static int GetIntVal(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                if (data.ToUpper() == "DESC" || data == "1")
                {
                    return 1;
                }
            }

            return 0;
        }
    }

}
