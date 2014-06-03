using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeCampServerLite.UI.Controllers
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class CarController : ApiController
    {
        public Car[] Get()
        {
            return new[]
            {
                new Car
                {
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2007
                },
                new Car
                {
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 1998
                },
                new Car
                {
                    Make = "Dodge",
                    Model = "Ram",
                    Year = 2006
                },
            };
        }

        public HttpResponseMessage Get(int id)
        {
            if (id != 4)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var model = new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 1998
            };
            return Request.CreateResponse(HttpStatusCode.Found, model);
        }

    }
}
