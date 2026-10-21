using System;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.Dtos
{
    public class IcoHolderItem
    {
        public string Url { get; set; }
        public string ProjName { get; set; }
        public string ImgUrl { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public double Percent { get; set; }
    }
}