using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;

namespace IcoReaderService.Reader
{
    public class ProjectDetailsReader
    {
        public static async Task<ProjectDetailsResult> Read(string url)
        {
            url = UrlHelper.Sanitize(url);
            ProjectDetailsResult result = new ProjectDetailsResult()
            {
                Links = new Dictionary<string,string>()
            };

            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);
            var cellSelector = ".socials-list-container a";
            var cells = document.QuerySelectorAll(cellSelector);

            foreach (var element in cells)
            {
                var key = element.Children[1].InnerHtml;
                var value = element.GetAttribute("href");
                if (!result.Links.ContainsKey(key))
                {
                    result.Links.Add(key, value);
                }
            }

            return result;
        }

        private static string GetTweetsCharacters(string twitterString)
        {
            var pos1 = twitterString.IndexOf("Tweets, current page.", StringComparison.Ordinal);
            return twitterString.Substring(pos1, 138);
        }
    }
}
