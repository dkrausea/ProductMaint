using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;

namespace AjaxExamples.Models
{

    public class CityRepository
    {
        const string _csvFilename = "App_Data/cities.csv";
        static readonly List<City> _cities;

        static CityRepository()
        {
            // We look up the directory using the HttpRuntime. 
            // In a real application we shouldn't do this, as it tightly ties the repository to ASP.NET
            // However, we use it here for simplicity so as not to detract from the example, which is primarily focused on AJAX.
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, _csvFilename);

            _cities = new List<City>();

            int id = 1;
            foreach (var line in File.ReadAllLines(path))
            {
                var lineSegments = line.Split(',');
                var name = lineSegments[0];
                var state = lineSegments[1];

                var city = new City {Id = id++, Name = name, State = state};
                _cities.Add(city);
            }
        }

        public City[] FindCities(string filter)
        {
            var cities = from city in _cities
                         where city.DisplayName.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase)
                         select city;

            return cities.ToArray();
        }
    }
}