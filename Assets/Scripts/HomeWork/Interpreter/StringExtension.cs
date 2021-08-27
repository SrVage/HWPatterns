namespace DefaultNamespace
{
    public static class StringExtension
    {
        public static string ShortText(this string str)
        {
            var number = float.Parse(str);
            if (number >= 1000 && number<1000000)
            {
                number = number / 1000;
                return number.ToString() + "K";
            }

            if (number >= 1000000)
            {
                number = number / 1000000;
                return number.ToString() + "M";
            }

            return str;
        }
    }
}