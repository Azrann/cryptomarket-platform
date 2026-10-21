using System;
using System.IO;
using Newtonsoft.Json;
using Tweetinvi;

namespace TwitterStream
{
	class Program
	{
		static void Main(string[] args1)
		{
			// Set up your credentials (https://apps.twitter.com)
			var cred = Auth.SetUserCredentials("REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE", "REPLACE_WITH_YOUR_VALUE");
			var pubSub = new PubSub();

			var stream = Tweetinvi.Stream.CreateFilteredStream();
			stream.AddTrack("real madrid");
			stream.MatchingTweetReceived += (sender, args) =>
			{
				if (args.Tweet.Text.StartsWith("RT "))
				{
					Console.WriteLine("Retweet: " + args.Tweet.Text);
					Console.WriteLine("URL: " + args.Tweet.Url);
					Console.WriteLine("********************************************************************");
					Console.WriteLine("");
					using (StreamWriter writetext = File.AppendText("log.txt"))
					{
						//writetext.WriteLine(JsonConvert.SerializeObject(args.Tweet));
						writetext.WriteLine("********************************************************************");
						writetext.WriteLine("********************************************************************");
					}
				}
				else
				{
					Console.WriteLine("Tweet: " + args.Tweet.Text);
					Console.WriteLine("URL: " + args.Tweet.Url);
					Console.WriteLine("********************************************************************");
					Console.WriteLine("");
					pubSub.Publish("twitter", args.Tweet.Url, args.Tweet.Text);
					using (StreamWriter writetext = File.AppendText("log.txt"))
					{
						//writetext.WriteLine(JsonConvert.SerializeObject(args.Tweet));
						writetext.WriteLine("********************************************************************");
						writetext.WriteLine("********************************************************************");
					}
				}
			};
			stream.StartStreamMatchingAllConditions();
		}
	}
}
