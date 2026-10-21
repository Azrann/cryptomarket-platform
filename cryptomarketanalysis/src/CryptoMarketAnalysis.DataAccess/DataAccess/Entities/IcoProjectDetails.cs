using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.Entities
{
    public class IcoProjectDetails : Entity<Guid>
    {

        public IcoProjectDetails(Guid Id) : base(Id)
        {
        }

        public IcoProjectDetails()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public string ProjName { get; set; }
        public string Description { get; set; }
        public string VideoDescriptionUrl { get; set; }
        public string About { get; set; }
        public string Features { get; set; }
        public string TechnicalInfo { get; set; }
        public string RoadmapJson { get; set; }
        public string LinksJson { get; set; }
        public string TeamJson { get; set; }
        public string AdvisorsJson { get; set; }
        public Dictionary<string, string> Roadmap =>
            JsonConvert.DeserializeObject<Dictionary<string, string>>(RoadmapJson);

        public List<string> Links => JsonConvert.DeserializeObject<List<string>>(LinksJson);

        public Dictionary<string, TeamMember> Team =>
            JsonConvert.DeserializeObject<Dictionary<string, TeamMember>>(TeamJson);

        public Dictionary<string, TeamMember> Advisors =>
            JsonConvert.DeserializeObject<Dictionary<string, TeamMember>>(AdvisorsJson);
    }

    public class IcoProject : Entity<Guid>
    {
        public IcoProject(Guid Id) : base(Id)
        {
        }

        public IcoProject()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public string ProjName { get; set; }
        public string ProjImgFileName { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public double Percent { get; set; }
        public decimal IcoHolderRating { get; set; }
        public decimal IcoBazarRating { get; set; }
        public decimal IcoBenchRating { get; set; }

        public decimal RatingAvg
        {
            get
            {
                int numRatings = IcoHolderRating > 0 ? 1 : 0;
                decimal total = IcoHolderRating;

                if (IcoBazarRating > 0)
                {
                    total += IcoBazarRating;
                    numRatings++;
                }

                if (IcoBenchRating > 0)
                {
                    total += IcoBenchRating;
                    numRatings++;
                }

                if (numRatings > 0)
                {
                    return (total) / numRatings;
                }

                return 0;
            }
        } 
    }
}
