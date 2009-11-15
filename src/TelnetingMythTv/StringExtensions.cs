
namespace TelnetingMythTv
{
    public static class StringExtensions
    {
        public static string format(this string stringToFormat, params object[] arguments)
        {
            return string.Format(stringToFormat, arguments);
        }
    }
}
