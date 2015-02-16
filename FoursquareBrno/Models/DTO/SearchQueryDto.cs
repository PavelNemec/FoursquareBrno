using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace FoursquareBrno.Models.DTO
{
    public class SearchQueryDto
    {
        public string Value { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}