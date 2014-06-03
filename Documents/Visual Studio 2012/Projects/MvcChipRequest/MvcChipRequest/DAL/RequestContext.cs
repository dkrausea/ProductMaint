using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcChipRequest.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcChipRequest.DAL
{
    public class RequestContext : DbContext
    {
        public DbSet<ChipRequest> ChipRequests { get; set; }
        public DbSet<Chip> Chips { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<ATP> ATPs { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<DemandStatus> DemandStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}