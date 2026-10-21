using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace TwitterStream
{
	class Facebook
	{
		public Facebook()
		{
		}

		public void Load()
		{
			/*FacebookClient fb = new FacebookClient("e2cc3bf1c908f9777013a1fe7893f559");

			// Make the friends list Open Graph API request
			var friendsTaskResult = await fb.GetTaskAsync(“/ me / friends”);

			var result = (IDictionary<string, object>)friendsTaskResult;
			var data = (IEnumerable<object>)result[“data”];
			foreach (var item in data)
			{
				var friend = (IDictionary<string, object>)item;
				// Pick out the properties from the dictionary without the need for writing deserializing classes

				string name = (string)friend[“name”];
				string id = (string)friend[“id”];
			}*/
		}
	}
}
