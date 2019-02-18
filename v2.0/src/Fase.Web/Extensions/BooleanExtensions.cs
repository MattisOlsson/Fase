namespace Fase.Web.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToString(this bool condition, string trueString, string falseString = null)
        {
            return condition
                ? trueString
                : falseString;
        }
    }
}