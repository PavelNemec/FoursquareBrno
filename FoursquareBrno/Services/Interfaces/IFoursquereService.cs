using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSquare.SharpSquare.Entities;
using FoursquareBrno.Models.DTO;

namespace FoursquareBrno.Services.Interfaces
{
    interface IFoursquereService
    {
        IEnumerable<Venue> GetVenues(SearchQueryDto searchQuery);

    }
}
