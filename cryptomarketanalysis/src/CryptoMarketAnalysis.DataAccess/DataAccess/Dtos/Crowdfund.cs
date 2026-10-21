namespace CryptoMarketAnalysis.DataAccess.DataAccess.Dtos
{
    public class Crowdfund
    {
        public int ProjID { get; set; }
        public string ProjName { get; set; }
        public string ProjDesc { get; set; }
        public int ProjCatID { get; set; }
        public string ProjCatName { get; set; }
        public int ProjPackageID { get; set; }
        public string PackageName { get; set; }
        public int ProjTopOfUpcoming { get; set; }
        public string ProjImageURL { get; set; }
        public string ProjImageLargeURL { get; set; }
        public string ProjURL { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string EventURL { get; set; }
        public double Percent { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
    }
}