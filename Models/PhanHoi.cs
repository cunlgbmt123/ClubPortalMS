//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubPortalMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PhanHoi
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> IdCLB { get; set; }
        [ForeignKey("IdCLB")]
        public virtual CLB CLB { get; set; }
    }
}
