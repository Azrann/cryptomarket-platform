using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptoMarketWeb.DataAccess.Entities;

namespace CryptoMarketWeb.Services
{
    public class RenderHelper
    {
        public static string GetCssNameFromType(string key)
        {
            switch (key)
            {
                case LinksKey.Website: return "fa-globe";
                case LinksKey.Blog: return "fa-bold";
                case LinksKey.Github: return "fa-github-square";
                case LinksKey.Instagram: return "fa-instagram";
                case LinksKey.Other: return "fa-external-link-square";
                case LinksKey.Paper: return "fa-file-pdf-o";
                case LinksKey.Reddit: return "fa-reddit-square";
                case LinksKey.Steemit: return " fa-bolt";
                case LinksKey.Youtube: return "fa-youtube-square";
                case LinksKey.BitcoinTalk: return "fa-bitcoin";
                case LinksKey.Facebook: return "fa-facebook-square";
                case LinksKey.LinkedIn: return "fa-linkedin-square";
                case LinksKey.Telegram: return "fa-telegram-plane";
                case LinksKey.Twitter: return "fa-twitter-square";
                case LinksKey.GooglePlus: return "fa-google-plus-square";
            }
            return "fa-link";
        }

        public static string GetCssNameFromUrl(string key)
        {
            return GetCssNameFromType(GetTypeFromUrl(key));
        }

        public static int GetColumnSizeByNumItems(int numItems, int maxItemsInRow)
        {
            if (numItems > 0)
            { 
                return (maxItemsInRow / numItems);
            }

            return maxItemsInRow;
        }

        public static string GetTypeFromUrl(string url)
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
    }
}