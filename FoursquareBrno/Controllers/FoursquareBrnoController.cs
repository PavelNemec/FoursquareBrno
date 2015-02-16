using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoursquareBrno.Models.DTO;
using FoursquareBrno.Services;
using FoursquareBrno.Services.Interfaces;

namespace FoursquareBrno.Controllers
{
    public class FoursquareBrnoController : Controller
    {
        private readonly IFoursquereService _foursquereService;
        private readonly ILogService _logService;

        public FoursquareBrnoController()
        {
                _foursquereService = new FoursquereService();
                _logService = new LogService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchVenues(SearchQueryDto searchQuery)
        {
            ViewBag.SameQueryValuesCount = 1;

            // Uncomment when you add connection string to Web.config

            //_logService.LogSearchQuery(searchQuery);
            //ViewBag.SameQueryValuesCount = _logService.SameQueryValuesCount(searchQuery.Value); 
            
            return View("VenueList", _foursquereService.GetVenues(searchQuery));
        }
    }
}