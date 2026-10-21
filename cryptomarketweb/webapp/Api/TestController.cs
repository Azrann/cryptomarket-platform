using Newtonsoft.Json;
using System.Web.Http;
using CryptoMarketWeb.DataAccess;

namespace SmartAdminMvc.Api
{
    public class TestController : ApiController
    {
        TweetsDbService _service;
        public TestController(TweetsDbService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public string Get()
        {
            return JsonConvert.SerializeObject(_service.GetTopOfDay());
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        //...
    }
}