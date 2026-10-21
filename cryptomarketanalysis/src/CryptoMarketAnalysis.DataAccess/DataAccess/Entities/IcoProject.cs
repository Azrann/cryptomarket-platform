using System;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.Entities
{
    //public class IcoProject : Entity<Guid>
    //{

    //    public IcoProject(Guid Id) : base(Id)
    //    {
    //    }

    //    public IcoProject()
    //    {
    //        this.Id = Guid.NewGuid();
    //        CreatedOn = DateTime.UtcNow;
    //        LastUpdated = DateTime.UtcNow;
    //    }

    //    public IcoProject(Crowdfund crowdfund)
    //    {
    //        this.Id = Guid.NewGuid();
    //        CreatedOn = DateTime.UtcNow;
    //        LastUpdated = DateTime.UtcNow;
    //        ProjID = crowdfund.ProjID;
    //        ProjName = crowdfund.ProjName;
    //        ProjDesc = crowdfund.ProjDesc;
    //        ProjCatID = crowdfund.ProjCatID;
    //        ProjCatName = crowdfund.ProjCatName;
    //        ProjPackageID = crowdfund.ProjPackageID;
    //        PackageName = crowdfund.PackageName;
    //        ProjTopOfUpcoming = crowdfund.ProjTopOfUpcoming;
    //        ProjImageURL = crowdfund.ProjImageURL;
    //        ProjImageLargeURL = crowdfund.ProjImageLargeURL;
    //        ProjURL = crowdfund.ProjURL;
    //        EventID = crowdfund.EventID;
    //        EventName = crowdfund.EventName;
    //        EventURL = crowdfund.EventURL;
    //        Percent = crowdfund.Percent;
    //        Status = crowdfund.Status;
    //        StatusID = crowdfund.StatusID;
    //        DateTime startDate;
    //        if (DateTime.TryParse(crowdfund.EventStartDate, out startDate))
    //        {
    //            EventStartDate = startDate;
    //        }
    //        else
    //        {
    //            EventStartDate = DateTime.MaxValue;
    //        }
    //        DateTime endDate;
    //        if (DateTime.TryParse(crowdfund.EventEndDate, out endDate))
    //        {
    //            EventEndDate = endDate;
    //        }
    //        else
    //        {
    //            EventEndDate = DateTime.MaxValue;
    //        }
    //    }


    //    public int ProjID { get; set; }
    //    public string ProjName { get; set; }
    //    public string ProjDesc { get; set; }
    //    public int ProjCatID { get; set; }
    //    public string ProjCatName { get; set; }
    //    public int ProjPackageID { get; set; }
    //    public string PackageName { get; set; }
    //    public int ProjTopOfUpcoming { get; set; }
    //    public string ProjImageURL { get; set; }
    //    public string ProjImageLargeURL { get; set; }
    //    public string ProjURL { get; set; }
    //    public int EventID { get; set; }
    //    public string EventName { get; set; }
    //    public DateTime EventStartDate { get; set; }
    //    public DateTime EventEndDate { get; set; }
    //    public string EventURL { get; set; }
    //    public double Percent { get; set; }
    //    public string Status { get; set; }
    //    public int StatusID { get; set; }
    //}
}
