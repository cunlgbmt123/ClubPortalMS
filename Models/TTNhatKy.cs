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

    public partial class TTNhatKy
    {
        public int ID { get; set; }
        public int IdThanhVien { get; set; }
        public DateTime TGThamGia { get; set; }
        public int SKDaThamGia { get; set; }
        [ForeignKey("IdThanhVien")]
        public virtual ThanhVien ThanhVien { get; set; }
    }
}
