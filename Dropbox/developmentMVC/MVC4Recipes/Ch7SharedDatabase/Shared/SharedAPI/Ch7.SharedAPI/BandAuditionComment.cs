//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch7.SharedAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class BandAuditionComment
    {
        public int BandAuditionCommentId { get; set; }
        public int BandAuditionId { get; set; }
        public int ArtistId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Vote { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual BandAudition BandAudition { get; set; }
    }
}
