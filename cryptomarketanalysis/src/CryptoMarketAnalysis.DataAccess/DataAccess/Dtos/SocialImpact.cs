namespace CryptoMarketAnalysis.DataAccess.DataAccess.Dtos
{
    public class SocialImpact
    {
        //BitcoinTalk
        public int Views { get; set; }
        //Telegram
        public int Members { get; set; }
        //Twitter
        public int Likes { get; set; }
        public int Followers { get; set; }
        public int Tweets { get; set; }
        public int Following { get; set; }
        public int Lists { get; set; }
        //Youtube
        public int Subscribers { get; set; }
        //Redituser
        public int Karma { get; set; }
        //LinkedIn
        public int LFollowers { get; set; }
        public int LEmployees { get; set; }
        //Medium
        public int MFollowers { get; set; }
        //StemmIt
        public int SFollowers { get; set; }
        public int SPosts { get; set; }
        //Instagram
        public int IFollowers { get; set; }
        public int IPosts { get; set; }

        public void Set(BitcointalkImpact bitcointalkImpact)
        {
            Views = bitcointalkImpact.Views;
        }

        public void Set(InstagramImpact instagramImpact)
        {
            IFollowers = instagramImpact.Followers;
            IPosts = instagramImpact.Posts;
        }

        public void Set(TelegramImpact telegramImpact)
        {
            Members = telegramImpact.Members;
        }

        public void Set(TwitterImpact twitterImpact)
        {
            Likes = twitterImpact.Likes;
            Followers = twitterImpact.Followers;
            Tweets = twitterImpact.Tweets;
            Following = twitterImpact.Following;
            Lists = twitterImpact.Lists;
        }

        public void Set(YoutubeImpact youtubeImpact)
        {
            Subscribers = youtubeImpact.Subscribers;
        }

        public void Set(MediumImpact mediumImpact)
        {
            MFollowers = mediumImpact.Followers;
        }

        public void Set(RedditImpact redditImpact)
        {
            Karma = redditImpact.Karma;
        }

        public void Set(SteemitImpact steemitImpact)
        {
            SFollowers = steemitImpact.Followers;
            SPosts = steemitImpact.Posts;
        }

        public void Set(LinkedInImpact linkedInImpact)
        {
            LFollowers = linkedInImpact.Followers;
            LEmployees = linkedInImpact.Employees;
        }
    }
}