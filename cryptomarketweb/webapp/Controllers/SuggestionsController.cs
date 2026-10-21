#region Using

using System;
using System.Web.Mvc;
using CryptoMarketWeb.DataAccess;
using CryptoMarketWeb.DataAccess.Entities;

#endregion

namespace SmartAdminMvc.Controllers
{
    public class SuggestionsController : Controller
    {
        IRepository<Suggestion> _repo;
        public SuggestionsController(IRepository<Suggestion> repo)
        {
            _repo = repo;
        }
        // GET: suggestions/index
        public ActionResult Index()
        {
            ViewBag.Title = $"CryptoMarketAnalysis suggestions";
            ViewBag.MetaDescription = $"Tell us, what would you like to see.";

            return View();
        }

        public ActionResult Add(Suggestion suggestion)
        {
            suggestion.Id = Guid.NewGuid();
            suggestion.CreatedOn = DateTime.Now;
            suggestion.LastUpdated = DateTime.Now;
            _repo.Add(suggestion);
            _repo.Save();
            TempData["SuggestionSent"] = true;
            return RedirectToAction("Index");
        }
    }

  /*  public class Suggestion
    {
        public string name { get; set; }
        public string email { get; set; }
        public string review { get; set; }
    }*/
}