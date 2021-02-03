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
    
    public partial class LabAnnouncement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LabAnnouncement()
        {
            this.Courses = new HashSet<Cours>();
            this.Publications = new HashSet<Publication>();
        }
    
        public int LabAnnouncementsID { get; set; }
        public Nullable<int> LabMembersID { get; set; }
        public Nullable<int> MemberCategoriesID { get; set; }
        public Nullable<int> PublicationMediaID { get; set; }
        public Nullable<int> PublicationsID { get; set; }
        public Nullable<int> ResearchProjectsID { get; set; }
        public Nullable<int> CoursesID { get; set; }
        public string Announcement { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
        public virtual Cours Cours { get; set; }
        public virtual LabMember LabMember { get; set; }
        public virtual MemberCategory MemberCategory { get; set; }
        public virtual PublicationMedia PublicationMedia { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual ResearchProject ResearchProject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
