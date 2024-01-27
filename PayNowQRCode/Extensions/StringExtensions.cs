namespace PayNowQRCode.Extensions
{
    internal static class StringExtensions
    {
        //returns length of string padded with 0 -- as per specifications
        public static string L(this string str, int n = 2, char padChar = '0')
        {
            string lenStr = str.Length.ToString().PadLeft(n, padChar);
            lenStr = lenStr.Substring(lenStr.Length - n);
            return lenStr;
        }

    }
}
