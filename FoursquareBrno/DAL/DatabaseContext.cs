using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using FoursquareBrno.Models;
using FoursquareBrno.Models.Abstract;

namespace FoursquareBrno.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
                
        }

        public virtual DbSet<Query> Query { get; set; }

        private void ProcessBaseEntity(IEnumerable<DbEntityEntry<BaseEntity>> baseEntitityEntries)
        {
            foreach (var baseEntityEntry in baseEntitityEntries)
            {
                if (baseEntityEntry.State == EntityState.Added)
                {
                    baseEntityEntry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ProcessBaseEntity(ChangeTracker.Entries<BaseEntity>());
            return base.SaveChanges();
        }

    }
}