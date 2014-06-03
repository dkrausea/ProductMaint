using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreCalifornia.API
{
    public partial class ApiClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();           
            client.BaseAddress = new Uri("http://localhost:50549/");            
            var tour = new Tour() { Name = ".NET Client Tour", Description = "Created with HttpClient", Length = 10, IncludesMeals = true, Price = 500, Rating = "Easy" };
            client.PostAsJsonAsync("api/tour", tour);
        }
    }
}