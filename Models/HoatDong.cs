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
    using System.Web;

    public partial class HoatDong
    {
        public HoatDong()
        {
            HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
            HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
        }
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string KeyWord { get; set; }
        public string URL { get; set; }
        public string HinhAnhChiTiet { get; set; }
        public string HinhAnhBaiViet { get; set; }
        public DateTime NgayDang { get; set; }
        public string TenNguoiDang { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageDetailFile { get; set; }

    }
}
