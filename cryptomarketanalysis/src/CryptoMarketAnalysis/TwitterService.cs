using System;
using Tweetinvi;
using Tweetinvi.Streaming;

namespace CryptoMarketAnalysis
{
    public class TwitterService
    {
        IFilteredStream stream;

        public TwitterService()
        {
            var cred = Auth.SetUserCredentials("REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE");

            stream = Tweetinvi.Stream.CreateFilteredStream();
            stream.AddTrack("BTC");
            stream.AddTrack("Bitcoin");
            stream.MatchingTweetReceived += (sender, args) =>
            {
                if (args.Tweet.Text.StartsWith("RT "))
                {
                    Console.WriteLine("Retweet: " + args.Tweet.Text);
                    Console.WriteLine("URL: " + args.Tweet.Url);
                    Console.WriteLine("********************************************************************");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Tweet: " + args.Tweet.Text);
                    Console.WriteLine("URL: " + args.Tweet.Url);
                    Console.WriteLine("********************************************************************");
                    Console.WriteLine("");
                }
            };
            
        }
        public void Start() { stream.StartStreamMatchingAllConditions(); }
        public void Stop() { stream.StopStream(); }
    }
}
