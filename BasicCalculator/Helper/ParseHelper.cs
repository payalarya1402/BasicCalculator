using System;
namespace BasicCalculator.Helper
{
    public static class ParseHelper
    {
        /*this function reads the nunbers from the input string
        //e.g input string is 122+5,
        input : ReadNumber("122+5",0)
        first it will get digit 112 and return to calling method and set startpointer to 3,
        second time inpur ("122+5",4) and it will return  digit 5 and set startpointer to 5
        */
        public static Decimal ReadNumber(this string s, ref int startPos)
        {
            int i;
            for (i = startPos; i != s.Length && (char.IsDigit(s[i]) || s[i] == '.' || (i == startPos && s[i] == '-')); i++) ;

            var num = s.Substring(startPos, i - startPos);
            startPos += i - startPos - 1;
            return decimal.Parse(num);
        }
    }
}

