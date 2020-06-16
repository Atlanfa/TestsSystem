using System.Text;

namespace TestsSystem.Web.Extensions
{
    public static class StringExtensions
    {
        public static string WithVers(this string endpoint, string vers)
            => new StringBuilder(vers).Append(endpoint).ToString();

        public static int ToId(this string data)
            => int.Parse(data.Split('-')[0]);

        public static int ToTryCount(this string data)
            => int.Parse(data.Split('-')[1]);
    }
}
