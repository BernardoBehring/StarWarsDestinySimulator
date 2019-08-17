using System.Web;

namespace StarWarsDestiny.Common.Util.Extensions
{
    public static class StringExtensions
    {
        public static string FormatText(this string value)
        {
            return HttpUtility.HtmlDecode(value).Replace("\n", "").Replace("\t", "").Trim();
        }
    }
}
