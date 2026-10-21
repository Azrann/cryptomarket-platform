using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using CryptoMarketWeb.DataAccess;
using NUnit.Framework;
using SimpleFeedReader;


namespace CryptoMarketWeb.Test
{
    [TestFixture]
    public class IcoDbServiceTest
    {

        [Test]
        public void WhenICallDbIGetAllIcos()
        {
            var service = new IcoDbService();
            var result = service.GetIcos();
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void WhenICallDbByProjNameIGetAnIco()
        {
            var service = new IcoDbService();
            var result = service.GetIcoByProjectName("Synthestech / STT");
            Assert.IsTrue(result != null);
        }

        [Test]
        public void WhenICallDbByProjNameIGetAnIcoDetails()
        {
            var service = new IcoDbService();
            var result = service.GetICoDetailByProjectName("Synthestech / STT");
            Assert.IsNotNull(result);
        }
    }
}
