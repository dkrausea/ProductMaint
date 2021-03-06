//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch7.R3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artist
    {
        public Artist()
        {
            this.ArtistSkills = new HashSet<ArtistSkill>();
        }
    
        public int ArtistId { get; set; }
        public Nullable<System.Guid> OldUserId { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string Provence { get; set; }
        public string City { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string WebSite { get; set; }
        public byte ProfilePrivacyLevel { get; set; }
        public byte ContactPrivacyLevel { get; set; }
        public long ProfileViews { get; set; }
        public Nullable<System.DateTime> ProfileLastViewDate { get; set; }
        public Nullable<byte> Rating { get; set; }
        public string AvatarURL { get; set; }
        public string EmailAddress { get; set; }
        public int FileUploadsInBytes { get; set; }
        public int FileUploadQuotaInBytes { get; set; }
        public System.DateTime LastActivityDate { get; set; }
        public bool ShowChatStatus { get; set; }
        public bool AllowChatSounds { get; set; }
    
        public virtual ICollection<ArtistSkill> ArtistSkills { get; set; }
    }
}
