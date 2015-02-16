using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FourSquare.SharpSquare.Core;
using FourSquare.SharpSquare.Entities;
using FoursquareBrno.DAL;
using FoursquareBrno.Globals;
using FoursquareBrno.Models.DTO;
using FoursquareBrno.Services.Interfaces;

namespace FoursquareBrno.Services
{
    public class FoursquereService : IFoursquereService
    {

        public SharpSquare SharpSquare { get; set; }

        public FoursquereService()
        {
            SharpSquare = new SharpSquare(ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["ClientSecret"]);
        }

        public IEnumerable<Venue> GetVenues(SearchQueryDto searchQuery)
        {
            if (String.IsNullOrEmpty(searchQuery.Latitude) || String.IsNullOrEmpty(searchQuery.Longitude))
            {
                return SharpSquare.SearchVenues(new Dictionary<string, string>
                {
                    {"near", "Brno"},
                    {"limit", "12"},
                    {"query", searchQuery.Value}
                }
                    );
            }

            return SharpSquare.SearchVenues(
                new Dictionary<string, string>
                {
                    {"limit", "12"},
                    {"ll", searchQuery.Latitude.Replace(",",".") + "," + searchQuery.Longitude.Replace(",",".")},
                    {"query", searchQuery.Value }
                }
                );
        }
    }
}