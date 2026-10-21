using System;

namespace IcoReaderService.Reader
{
    internal class UrlHelper
    {
        internal static string Sanitize(string url)
        {
            if (!url.Contains("http"))
            {
                return $"https://{url}";
            }
            return url;
        }
    }
}