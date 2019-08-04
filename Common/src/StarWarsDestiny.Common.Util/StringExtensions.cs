using System.Web;

namespace StarWarsDestiny.Common.Util
{
    public static class StringExtensions
    {
        public static string FormatText(this string value)
        {
            return HttpUtility.HtmlDecode(value).Replace("\n", "").Replace("\t", "").Trim();
        }
    }
}
