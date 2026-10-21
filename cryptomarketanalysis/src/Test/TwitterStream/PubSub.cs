using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PubnubApi;

namespace TwitterStream
{
	public class PubSub
	{
		private PNConfiguration _config;

		public PubSub()
		{
			_config = new PNConfiguration
			{
				SubscribeKey = "REPLACE_WITH_YOUR_VALUE",
				PublishKey = "REPLACE_WITH_YOUR_VALUE"
			};
		}

		public void Publish(string origin, string url, string text)
		{
			var pubnub = new Pubnub(_config);
			var message = new
			{
				text = text,
				origin = origin,
				url = url
			};

			pubnub.Publish()
				.Channel("tone")
				.Message(message)
				.Sync();
		}
	}
}
