using System;
using System.Collections.Generic;
using System.Linq;
using CryptoMarketWeb.Models;
using Newtonsoft.Json;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class IcoProjectDetails : Entity<Guid>
    {
        public IcoProjectDetails(Guid Id) : base(Id)
        {
        }

        public IcoProjectDetails()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public string ProjName { get; set; }
        public string Description { get; set; }
        public string VideoDescriptionUrl { get; set; }
        public string About { get; set; }
        public string Features { get; set; }
        public string TechnicalInfo { get; set; }
        public string RoadmapJson { get; set; }
        public string LinksJson { get; set; }
        public string TeamJson { get; set; }
        public string AdvisorsJson { get; set; }
        public Dictionary<string, string> Roadmap =>
            JsonConvert.DeserializeObject<Dictionary<string, string>>(RoadmapJson);

        public Dictionary<string, string> Links
        {
            get
            {
                var list = JsonConvert.DeserializeObject<List<string>>(LinksJson);
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (var url in list)
                {
                    var key = GetTypeFromUrl(url);
                    if (!result.ContainsKey(key))
                    {
                        result.Add(key,url);
                    }
                }
               
                return result;
            }
        }

        private string GetTypeFromUrl(string url)
        {
            if (url.Contains("bitcointalk"))
            {
                return LinksKey.BitcoinTalk;
            }
            if (url.Contains("t.me"))
            {
                return LinksKey.Telegram;
            }
            if (url.Contains("facebook"))
            {
                return LinksKey.Facebook;
            }
            if (url.Contains("twitter"))
            {
                return LinksKey.Twitter;
            }
            if (url.Contains("linkedin"))
            {
                return LinksKey.LinkedIn;
            }
            if (url.Contains("reddit"))
            {
                return LinksKey.Reddit;
            }
            if (url.Contains("paper"))
            {
                return LinksKey.Paper;
            }
            if (url.Contains("instagram"))
            {
                return LinksKey.Instagram;
            }
            if (url.Contains("medium"))
            {
                return LinksKey.Blog;
            }
            if (url.Contains("steemit"))
            {
                return LinksKey.Steemit;
            }
            if (url.Contains("github"))
            {
                return LinksKey.Github;
            }
            if (url.Contains("youtube"))
            {
                return LinksKey.Youtube;
            }
            if (url.Contains("google"))
            {
                return LinksKey.GooglePlus;
            }
            return LinksKey.Other;
        }
        public Dictionary<string, TeamMember> Team =>
            JsonConvert.DeserializeObject<Dictionary<string, TeamMember>>(TeamJson);

        public Dictionary<string, TeamMember> Advisors =>
            JsonConvert.DeserializeObject<Dictionary<string, TeamMember>>(AdvisorsJson);
    }

    public class IcoProject : Entity<Guid>
    {
        public IcoProject(Guid Id) : base(Id)
        {
        }

        public IcoProject()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public string ProjName { get; set; }
        public string ProjImgFileName { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public double Percent { get; set; }
        public decimal IcoHolderRating { get; set; }
        public decimal IcoBazarRating { get; set; }
        public decimal IcoBenchRating { get; set; }

        public decimal RatingAvg
        {
            get
            {
                int numRatings = IcoHolderRating > 0 ? 1 : 0;
                decimal total = IcoHolderRating;

                if (IcoBazarRating > 0)
                {
                    total += IcoBazarRating;
                    numRatings++;
                }

                if (IcoBenchRating > 0)
                {
                    total += IcoBenchRating;
                    numRatings++;
                }

                if (numRatings > 0)
                {
                    return Math.Round((total) / numRatings, 2); 
                }

                return 0;
            }
        }
    }

    public class LinksKey
    {
        public const string Website = "Website";
        public const string Paper = "Paper";
        public const string BitcoinTalk = "Bitcoin Talk";
        public const string Github = "Github";
        public const string Twitter = "Twitter";
        public const string Youtube = "Youtube";
        public const string Telegram = "Telegram";
        public const string Instagram = "Instagram";
        public const string Blog = "Blog";
        public const string Reddit = "Reddit";
        public const string Steemit = "Steemit";
        public const string LinkedIn = "LinkedIn";
        public const string Facebook = "Facebook";
        public const string Other = "Other";
        public const string GooglePlus = "GooglePlus";
    }
}
