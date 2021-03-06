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

    public partial class QLDSHoatDong
    {
        public int ID { get; set; }
        public string ChuDe { get; set; }
        public string Mota { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public string NoiDung { get; set; }
        public string DiaDiem { get; set; }
        public string TenFile { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
        public int IdCLB { get; set; }
        public int IdLoaiHD { get; set; }
        [ForeignKey("IdCLB")]
        public virtual CLB CLB { get; set; }
        [ForeignKey("IdLoaiHD")]
        public virtual LoaiHD LoaiHD { get; set; }
    }
}
