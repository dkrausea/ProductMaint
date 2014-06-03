using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcFFA_SURF.Models; 

namespace MvcFFA_SURF.Models
{
    public class MvcFFA_SURFContext : DbContext
    {
        public DbSet<MvcFFA_SURF.Models.MCNumber> MCNs { get; set; }
        public DbSet<MvcFFA_SURF.Models.ChipRequest> ChipRequests { get; set; }
        public DbSet<MvcFFA_SURF.Models.ATP> ATPs { get; set; }
        public DbSet<MvcFFA_SURF.Models.Demand> Demands { get; set; }
        public DbSet<MvcFFA_SURF.Models.Release> Releases { get; set; }
        public DbSet<MvcFFA_SURF.Models.Person> People { get; set; }
        public DbSet<MvcFFA_SURF.Models.Category> Categories { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 

    }
}