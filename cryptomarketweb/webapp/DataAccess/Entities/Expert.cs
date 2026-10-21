using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class Expert : Entity<Guid>
    {

        public Expert(Guid Id): base(Id)
        {
        }

        public Expert() 
        {
        }

        [StringLength(65)]
        public string Website { get; set; }
        [StringLength(65)]
        public string TwitterUrl { get; set; }
        [StringLength(65)]
        public string YoutubeUrl { get; set; }
        [StringLength(65)]
        public string InstagramUrl { get; set; }
        [StringLength(65)]
        public string FacebookUrl { get; set; }
        [StringLength(65)]
        public string OtherUrl { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(65)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Country { get; set; }
        public bool CryptoExpert { get; set; }
        public bool ICOExpert { get; set; }
        public bool Verified { get; set; }

        [StringLength(250)]
        public string Bio { get; set; }
        public string FollowersJson { get; set; }
        [StringLength(65)]
        public string ImageUrl { get; set; }
    }
}
