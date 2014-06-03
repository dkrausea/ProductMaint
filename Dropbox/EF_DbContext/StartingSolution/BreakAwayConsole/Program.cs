using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using DataAccess;
using Model;

namespace BreakAwayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

            // Call the latest example method here
            //PrintAllDestinations();
            //PrintAustralianDestinations();
            PrintDestinationNameOnly();
            // NOTE: Some examples will change data in the database. Ensure that you only call the 
            //       latest example method. The InitializeBagaDatabaseWithSeedData database initializer 
            //       (registered above) will take care of resetting the database before each run.
        }

        // Add example methods here


        private static void PrintAllDestinations()
        {
            using (var context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            orderby d.Name
                            select d;

                Console.WriteLine("All Destinations");
                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
                Console.WriteLine("**********");
            }
        }
        private static void PrintAustralianDestinations()
        {
            using (var context = new BreakAwayContext())
            {
                var query = context.Destinations
                            .Where(d => d.Country == "Australia")
                            .OrderBy(d => d.Name);

                Console.WriteLine("Australian Destinations");
                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }

        }

        private static void PrintDestinationNameOnly()
        {
            using (var context = new BreakAwayContext())
            {
                var query = context.Destinations
                            .Where(d => d.Country == "Australia")
                            .OrderBy(d => d.Name)
                            .Select(d => d.Name);
                foreach (var name in query)
                {
                    Console.WriteLine(name);
                }
            }
        }

    }
}
