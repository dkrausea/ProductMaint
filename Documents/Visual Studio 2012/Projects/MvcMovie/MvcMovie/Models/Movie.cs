using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public partial class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
        public int Stars { get; set; }
        public double RottenTomatoes { get; set; }
    }
}
