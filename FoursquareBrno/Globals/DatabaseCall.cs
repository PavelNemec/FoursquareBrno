using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoursquareBrno.DAL;

namespace FoursquareBrno.Globals
{
    public static class DatabaseHelper
    {
        private const string DbContext = "DatabaseContext";

        public static DatabaseContext Db
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(DbContext))
                {
                    HttpContext.Current.Items.Add(DbContext, new DatabaseContext());
                }

                return HttpContext.Current.Items[DbContext] as DatabaseContext;
            }
        }

        public static void Save()
        {
            // Getting dbContext directly to avoid creating it in case it was not already created.
            var entityContext = HttpContext.Current.Items[DbContext] as DatabaseContext;
            if (entityContext != null)
            {
                entityContext.SaveChanges();
            }
        }

        /// <summary>
        /// Called automatically on Application_EndRequest()
        /// </summary>
        public static void DisposeDbContext()
        {
            // Getting dbContext directly to avoid creating it in case it was not already created.
            var entityContext = HttpContext.Current.Items[DbContext] as DatabaseContext;
            if (entityContext != null)
            {
                entityContext.SaveChanges();
                entityContext.Dispose();
                HttpContext.Current.Items.Remove(DbContext);
            }
        }

    }
}