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
        /// <summary>
        /// Set every aritmetical operation's variable to false except for the variable given as an argument. 
        /// For Example SetFalse(add:true)
        /// </summary>
        public static void SetFalse(bool add = false, bool sub = false, bool multi = false, bool div = false)
        {
            addiction = add;
            substration = sub;
            multiplication = multi;
            division = div;
        }
    }
}
