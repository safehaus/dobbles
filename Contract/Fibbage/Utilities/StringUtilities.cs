using System;
using System.Text;

namespace Safehaus.IntranetGaming.Contract.Fibbage.Utilities
{
    public static class StringUtilities
    {
        private static Random r = new Random();

        public static char GetRandomCharacter()
        {
            int num = r.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }

        public static string GetRandomString(int length)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(GetRandomCharacter());
            }
            return sb.ToString();
        }
    }
}
