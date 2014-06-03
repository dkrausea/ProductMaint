using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcChipRequest.Models;

namespace MvcChipRequest.ViewModels
{
   public class ChipRequestIndexData
   {
      public IEnumerable<Chip> Chips { get; set; }
      public IEnumerable<ChipRequest> ChipRequests { get; set; }
      public IEnumerable<Demand> Demands { get; set; }
      public IEnumerable<ATP> ATPs { get; set; }
      public IEnumerable<Release> Releases { get; set; }
   }
}