using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeCampServerLite.UI.Models
{
    public class AttendeeEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ConferenceId { get; set; }

        [HiddenInput]
        [DisplayName("Conference Name")]
        public string ConferenceName { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(40)]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}