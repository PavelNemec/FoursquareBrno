using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FoursquareBrno.Models.Abstract;

namespace FoursquareBrno.Models
{
    public class Query : BaseEntity
    {
        public long QueryId { get; set; }

        public String Value { get; set; }

        public Query()
        {
                
        }

        public Query(string value)
        {
            Value = value;
        }
    }
}