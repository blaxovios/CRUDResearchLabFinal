//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDResearchLabFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publication()
        {
            this.LabAnnouncements = new HashSet<LabAnnouncement>();
            this.ResearchProjects = new HashSet<ResearchProject>();
        }
    
        public int PublicationsID { get; set; }
        public string ThematicUnit { get; set; }
        public Nullable<int> LabMembersID { get; set; }
        public Nullable<int> PublicationYear { get; set; }
        public Nullable<int> PublicationMediaID { get; set; }
        public Nullable<int> ResearchProjectsID { get; set; }
        public Nullable<int> LabAnnouncementsID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabAnnouncement> LabAnnouncements { get; set; }
        public virtual LabAnnouncement LabAnnouncement { get; set; }
        public virtual LabMember LabMember { get; set; }
        public virtual PublicationMedia PublicationMedia { get; set; }
        public virtual ResearchProject ResearchProject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResearchProject> ResearchProjects { get; set; }
    }
}