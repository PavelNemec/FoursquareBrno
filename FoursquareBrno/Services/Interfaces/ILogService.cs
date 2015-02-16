using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoursquareBrno.Models.DTO;

namespace FoursquareBrno.Services.Interfaces
{
    interface ILogService
    {
        void LogSearchQuery(SearchQueryDto searchQuery);

        int SameQueryValuesCount(string value);
    }
}
