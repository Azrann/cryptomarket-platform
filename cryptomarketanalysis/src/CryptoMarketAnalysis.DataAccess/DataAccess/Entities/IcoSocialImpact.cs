using System;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.Entities
{
    public class IcoSocialImpact : Entity<Guid>
    {
        public IcoSocialImpact(Guid Id) : base(Id)
        {
        }

        public IcoSocialImpact()
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public IcoSocialImpact(IcoLinks icoLinks)
        {
            this.Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
            ProjID = icoLinks.ProjID;
            ProjName = icoLinks.ProjName;
        }

        public void Set(SocialImpact impact)
        {
            //BitcoinTalk
            Views = impact.Views;
            //Telegram
            Members = impact.Members;
            //Twitter
            Likes = impact.Likes;
            Followers = impact.Followers;
            Tweets = impact.Tweets;
            Following = impact.Following;
            Lists = impact.Lists;
            //Youtube
            Subscribers = impact.Subscribers;
            //Redituser
            Karma = impact.Karma;
            //LinkedIn
            LFollowers = impact.LFollowers;
            LEmployees = impact.LEmployees;
            //Medium
            MFollowers = impact.MFollowers;
            //StemmIt
            SFollowers = impact.SFollowers;
            SPosts = impact.SPosts;
            //Instagram
            IFollowers = impact.IFollowers;
            IPosts = impact.IPosts;
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
    }
}
