using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Michael Sullivan\Desktop\Exercise Files\Ch5\ExploreCalifornia\ExploreCalifornia\App_Data\ExploreCalifornia.mdf;Integrated Security=True")
        {

        }

        public DbSet<Tour> Tours { get; set; }
    }
}