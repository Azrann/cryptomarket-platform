using System.ComponentModel.DataAnnotations;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class Tweet : Entity<long>
    {

        public Tweet(long Id): base(Id)
        {
        }

        public Tweet() 
        {
        }

        [StringLength(65)]
        public string Url { get; set; }
        public long Author { get; set; }
        [StringLength(355)]
        public string FullText { get; set; }
    }
}
