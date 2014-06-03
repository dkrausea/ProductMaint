using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CodeCampServerLite.UI.Models
{
    public class ConferenceXmlModel
    {
        [XmlAttribute]
        public string EventName;
        public string SessionCount;
        public string AttendeeCount;
    }
}