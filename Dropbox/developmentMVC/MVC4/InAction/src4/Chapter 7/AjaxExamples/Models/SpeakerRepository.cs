using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AjaxExamples.Models
{
    public class SpeakerRepository
    {
        //simulate an in memory database
        private static readonly List<Speaker> _speakers = new List<Speaker>();

        static SpeakerRepository()
        {
            _speakers = new List<Speaker> {

               new Speaker
                {
                    Id = 1,
                    FirstName = "Jimmy",
                    LastName = "Bogard",
                    PictureUrl = "/content/jimmy.png",
                    Bio = "Jimmy is a Principal Consultant at Headspring Systems in Austin, TX.",
                },
                new Speaker
                {
                    Id = 2,
                    FirstName = "Jeffrey",
                    LastName = "Palermo",
                    PictureUrl = "/content/jeffrey.jpg",
                    Bio = "Jeffrey Palermo is a Microsoft MVP and Chief Technology Officer of Headspring Systems in Austin, TX.",
                },
                new Speaker
                {
                    Id = 3,
                    FirstName = "Eric",
                    LastName = "Hexter",
                    PictureUrl = "/content/eric.jpg",
                    Bio = "Eric Hexter is an Enterprise Architect at Dell in Austin, TX.",
                },
                new Speaker
                {
                   Id = 4,
                   FirstName = "Matt",
                   LastName = "Hinze",
                   PictureUrl = "/content/matt.jpg",
                   Bio = "Matt Hinze is a Principal Consultant at Headspring Systems in Austin, TX.",
                },

               new Speaker
                {
                    Id = 5,
                    FirstName = "Jeremy",
                    LastName = "Skinner",
                    PictureUrl = "/content/jeremy.jpg",
                    Bio = "Jeremy Skinner is a C#/ASP.NET software developer in the UK.",
                }
            };

            
        }

        public IEnumerable<Speaker> FindAll()
        {
            return _speakers;
        }

        public Speaker FindSpeaker(int id)
        {
            return _speakers.SingleOrDefault(x => x.Id == id);
        }
    }
}