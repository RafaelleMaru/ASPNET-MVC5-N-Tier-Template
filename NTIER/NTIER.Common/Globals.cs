using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common
{
    public static class Globals
    {

        public const string KEY = "ApOpRsL53N3d1@D*";
        public const string MASK_KEY = "XXXXXXXXX";
        public const string REMEMBER_ME_KEY = "84rK*wSd%$K5Lm^H";
        public static Guid TokenID;
        public static List<KeyValuePair<int, string>> Settings = new List<KeyValuePair<int, string>>();
        public static string Username;

        public const string DEFAULT_PASSWORD = "password";

    }
}
