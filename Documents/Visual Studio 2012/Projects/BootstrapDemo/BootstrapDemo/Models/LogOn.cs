using System;
using System.Collections.Generic;

namespace BootstrapDemo.Models
{
    public class LogOn
    {
        public int LogOnID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ChooseFile { get; set; }
        public bool CheckMeOut { get; set; }
    }
}