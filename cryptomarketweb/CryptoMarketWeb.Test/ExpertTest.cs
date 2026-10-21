using System;
using System.Linq;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Entities;
using NUnit.Framework;

namespace CryptoMarketWeb.Test
{
    [TestFixture]
    public class ExpertTest
    {
        [Test]
        public void WhenICreateAnExpertICanRetrieveIt()
        {
            var expertContext = new ExpertContext();
            var expertRepo = new Repository<Expert>(expertContext);
            var id = Guid.NewGuid();
            var expert = new Expert(id)
            {
                Name = $"Name{id}".Substring(0,19),
                Country = "UK",
                CreatedOn = DateTime.Now,
                CryptoExpert = false,
                ICOExpert = true,
                InstagramUrl = $"http://instagramUrl/{id}",
                TwitterUrl = $"http://twitterUrl/{id}",
                Website = $"http://websiteurl/{id}",
                YoutubeUrl = $"http://youtubeurl/{id}",
                OtherUrl = $"http://medium/{id}",
                FacebookUrl = $"http://facebook/{id}",
                LastUpdated = DateTime.Now,
                Bio = @"Phil is a real estate broker for the East Boston neighborhood, and he's mastered the art of adding a warm personality to the professional bio on his website.
                        and economic growth in our neighborhood'."
            };

            expertRepo.Add(expert);
            expertRepo.Save();

            var result = expertRepo.GetAll(x => x.Id == id);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void WhenIGetICOExpertICanRetrieveThem()
        {
            var expertService = new ExpertDbService();
            var result = expertService.GetIcoExperts();
            Assert.IsTrue(result.Any());
        }
    }
}
