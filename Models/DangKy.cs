//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DangKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DangKy()
        {
            this.ChoXetDuyet = new HashSet<ChoXetDuyet>();
        }
    
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MSSV { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public Nullable<System.DateTime> NgayDangKy { get; set; }
        public string TrangThai { get; set; }
        public Nullable<int> IdCLB { get; set; }
    
        public virtual CLB CLB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChoXetDuyet> ChoXetDuyet { get; set; }
    }
}
