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
    
    public partial class CollaborationSpaceInvite
    {
        public int CollaborationSpaceInviteId { get; set; }
        public int CollaborationSpaceId { get; set; }
        public string EmailAddress { get; set; }
        public int ArtistId { get; set; }
        public Nullable<int> BandId { get; set; }
        public System.Guid LinkIdentifier { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual CollaborationSpace CollaborationSpace { get; set; }
    }
}
