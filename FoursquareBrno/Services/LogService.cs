using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoursquareBrno.Globals;
using FoursquareBrno.Models;
using FoursquareBrno.Models.DTO;
using FoursquareBrno.Services.Interfaces;

namespace FoursquareBrno.Services
{
    public class LogService : ILogService
    {
        public void LogSearchQuery(SearchQueryDto searchQuery)
        {
            DatabaseHelper.Db.Query.Add(new Query(searchQuery.Value));
            DatabaseHelper.Db.SaveChanges();
        }

        public int SameQueryValuesCount(string value)
        {
            return DatabaseHelper.Db.Query.Count(q => q.Value == value);
        }
    }
}