using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator
{
    public static class Operation
    {
        public static bool addiction = false;
        public static bool substration = false;
        public static bool multiplication = false;
        public static bool division = false;

        public static void SetFalse(bool add = false, bool sub = false, bool multi = false, bool div = false)
        {
            addiction = add;
            substration = sub;
            multiplication = multi;
            division = div;
        }
    }
}
