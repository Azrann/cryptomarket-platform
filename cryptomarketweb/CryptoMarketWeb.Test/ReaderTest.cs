using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using SimpleFeedReader;


namespace CryptoMarketWeb.Test
{
    [TestFixture]
    public class ReaderTest
    {

        [Test]
        public void Bla()
        {
            var reader = new CoinTelegraphReader();
            var result = reader.GetItems();
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void Bla2()
        { 
        }
    }
}
