namespace Manager.Application.Extensions
{
    public static class StringExtensions
    {
        public static string TrimSafe(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();

            return null;
        }

        public static string ToUpperSafe(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim().ToUpper();

            return null;
        }
    }
}
