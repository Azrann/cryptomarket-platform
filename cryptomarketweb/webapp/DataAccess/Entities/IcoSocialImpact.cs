using System;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class IcoSocialImpact : Entity<Guid>
    {
        public IcoSocialImpact(Guid Id) : base(Id)
        {
        }

        public IcoSocialImpact()
        {
        }

        public int ProjID { get; set; }
        public string ProjName { get; set; }

        //BitcoinTalk
        public int Views { get; set; }

        //Telegram
        public int Members { get; set; }

        //Twitter
        public int Likes { get; set; }
        public int Followers { get; set; }
        public int Tweets { get; set; }
        public int Following { get; set; }

        public int Lists { get; set; }

        //Youtube
        public int Subscribers { get; set; }

        //Redituser
        public int Karma { get; set; }

        //LinkedIn
        public int LFollowers { get; set; }

        public int LEmployees { get; set; }

        //Medium
        public int MFollowers { get; set; }

        //StemmIt
        public int SFollowers { get; set; }

        public int SPosts { get; set; }

        //Instagram
        public int IFollowers { get; set; }
        public int IPosts { get; set; }

        public int SocialImpact {
            get
            {
                return Karma + Members + Followers + Subscribers + LFollowers + MFollowers + SFollowers + IFollowers +
                       Convert.ToInt32((Views + Tweets + Lists + SPosts + IPosts) * 0.2);
            }
        }
    }
}