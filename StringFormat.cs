using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public static class StringFormat
    {
        // удаляем из строки original символы другой строки
        public static string DeleteSymbols(string original, string unnecessarySymbols)
        {
            char[] tempStr = unnecessarySymbols.ToCharArray();
            for (int i = 0; i < tempStr.Length; i++)
            {
                original = original.Replace((unnecessarySymbols[i]).ToString(), "");
            }
            return original;
        }

        public static bool NotInString(string str, string not)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == not) return false;
            }
            return true;
        }
        public static string DeleteRepeatSymbols(string str)
        {
            string newStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (NotInString(newStr, str[i].ToString())) newStr += str[i];
            }
            return newStr;
        }
    }

    
}
