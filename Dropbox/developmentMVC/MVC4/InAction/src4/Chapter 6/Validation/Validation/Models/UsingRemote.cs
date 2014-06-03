using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class UsingRemote
    {
        [Required]
        [Remote("IsNumberEven", "Home", ErrorMessage = "The number is odd.")]
        public int EvenNumber { get; set; } 
    }
}