using System.Data.Entity;
using CleanRoom.Models;

namespace  CleanRoom.DAL
{
    public class CleanroomContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CleanRoom.DAL.CleanroomContext>());

        public CleanroomContext()
            : base("name=CleanroomContext")
        {
        }

        public DbSet<WaferLot> WaferLots { get; set; }

        public DbSet<HomeBoat> HomeBoats { get; set; }

        public DbSet<LotStatus> LotStatus { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Foup> Foups { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<Wafer> Wafers { get; set; }

        public DbSet<WaferStatus> WaferStatus { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<WaferFailCode> WaferFailCodes { get; set; }

        public DbSet<Foundry> Foundries { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<PTE> PTEs { get; set; }

        public DbSet<MCN> MCNs { get; set; }
    }
}
