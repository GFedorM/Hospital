namespace Hospital.Staff.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimOrNull(this string value)
        {
            var trimmedValue = value?.Trim(' ', '\n', '\t', '\r', '\0');
            return trimmedValue.IsNullOrEmpty()
                ? null
                : trimmedValue;
        }
    }
}
