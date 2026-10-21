using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.Entities
{
    public class IcoLinks : Entity<Guid>
    {
        public IcoLinks(Guid Id) : base(Id)
        {
        }

        public IcoLinks()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public IcoLinks(IcoProject crowdfund)
        {
            this.Id = crowdfund.Id;
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
            ProjName = crowdfund.ProjName;
        }

        public void SetLinks(Dictionary<string, string> links)
        {
            JsonLinks = JsonConvert.SerializeObject(links);
        }

        public Dictionary<string, string> GetLinks()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonLinks);
        }

        public int ProjID { get; set; }
        public string ProjName { get; set; }
        public string JsonLinks { get; set; }
    }
}
