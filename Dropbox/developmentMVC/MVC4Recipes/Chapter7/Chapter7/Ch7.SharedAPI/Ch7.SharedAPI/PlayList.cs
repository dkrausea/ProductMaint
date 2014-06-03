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
    
    public partial class PlayList
    {
        public PlayList()
        {
            this.PlaylistItems = new HashSet<PlaylistItem>();
        }
    
        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public Nullable<int> ArtistId { get; set; }
        public Nullable<int> BandId { get; set; }
        public bool IsSitePlaylist { get; set; }
        public bool IsDefaultPlaylist { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Band Band { get; set; }
        public virtual ICollection<PlaylistItem> PlaylistItems { get; set; }
    }
}
