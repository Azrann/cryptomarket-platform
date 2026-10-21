using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMarketWeb.DataAccess.Entities
{
    public class Suggestion : Entity<Guid>
    {

        public Suggestion(Guid Id) : base(Id)
        {
        }

        public Suggestion()
        {
        }

        [StringLength(25)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        public string Text { get; set; }
    }
}