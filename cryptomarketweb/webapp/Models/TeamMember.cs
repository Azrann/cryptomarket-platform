using System;

namespace CryptoMarketWeb.Models
{
    public class TeamMember
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string LinkedInUrl { get; set; }
        public string PictureUrl { get; set; }
        public string PictureFileName { get; set; }
    }
}