using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.Models
{
    public class TinTuc
    {
        public TinTuc()
        {
            HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
            HinhAnhBaiViet = "~/Areas/Admin/Resource/Video/addImg.jpg";
        }
        [NotMapped]
        public HttpPostedFileBase ImageFileChitiet { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFileBaiviet { get; set; }
        [Key]
        public int ID { get; set; }
        public string TieuDe{ get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }

        public string KeyWord { get; set; }
        public string URL { get; set; }
        public string HinhAnhBaiViet { get; set; }
        public string HinhAnhChiTiet { get; set; }
        public DateTime NgayDang { get; set; }
        public string TenNguoiDang { get; set; }
        
    }
}