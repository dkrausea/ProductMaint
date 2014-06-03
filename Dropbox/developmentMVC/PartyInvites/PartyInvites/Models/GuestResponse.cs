using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage= "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }


        private MailMessage BuildMailMessage()
        {
            var message = new StringBuilder();
            message.AppendFormat("Date: {0:yyyy-MM-dd hh:mm}\n", DateTime.Now);
            message.AppendFormat("RSVP from: {0}\n", Name);
            message.AppendFormat("Email: {0}\n", Email);
            message.AppendFormat("Phone: {0}\n", Phone);
            message.AppendFormat("Can come: {0}\n", WillAttend.Value ? "Yes" : "No");
            return new MailMessage(
                "dkrause@qti.qualcomm.com",                                            // From
                "don.krausea@gamil.com",                                 // To
                Name + (WillAttend.Value ? " will attend" : " won't attend"), // Subject
                message.ToString()                                            // Body
            );
        }

        public void Submit() // .NET 4 version
        {
            using (var smtpClient = new SmtpClient())
            using (var mailMessage = BuildMailMessage())
            {
                smtpClient.Send(mailMessage);
            }
        }

    }
}