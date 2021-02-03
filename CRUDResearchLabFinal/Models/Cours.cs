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
    
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            this.LabAnnouncements = new HashSet<LabAnnouncement>();
        }
    
        public int CoursesID { get; set; }
        public string Undergraduate { get; set; }
        public string Postgraduate { get; set; }
        public Nullable<int> LabMembersID { get; set; }
        public Nullable<int> LabAnnouncementsID { get; set; }
    
        public virtual LabAnnouncement LabAnnouncement { get; set; }
        public virtual LabMember LabMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabAnnouncement> LabAnnouncements { get; set; }
    }
}
