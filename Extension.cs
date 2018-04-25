using System;

namespace Assets._scripts.GU_04_04_2018
{
    public static class Extension
    {
        public static string Format(this string format, params object[] arg)
        {
            return String.Format(format, arg);
        }
    }
}