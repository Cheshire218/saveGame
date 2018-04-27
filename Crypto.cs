using System;

namespace Assets._scripts.GU_04_04_2018
{
    public static class Crypto
    {
        public static string CryptoXOR(string text)
        {
            string result = String.Empty;
            foreach (var symbol in text)
            {
                result += (char)(symbol ^ 42);
            }
            return result;
        }
    }
}