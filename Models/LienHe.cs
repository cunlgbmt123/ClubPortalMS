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
    using System.ComponentModel.DataAnnotations;

    public partial class LienHe
    {
        [Key]
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string DiaChi { get; set; }
        public string HotLine { get; set; }
        public string Email { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }
    }
}
