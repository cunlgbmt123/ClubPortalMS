using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.HoatDong
{
    public class HoatdongViewModels
    {
        public HoatdongViewModels()
        {
            HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
            HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
        }
        public int ID { get; set; }
        [DisplayName("Tên Hoạt Động")]
        public string Ten { get; set; }
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }
        public string KeyWord { get; set; }
        public string URL { get; set; }
        [DisplayName("Hình Ảnh Chi Tiết")]
        public string HinhAnhChiTiet { get; set; }
        [DisplayName("Hình Ảnh Bài Viết")]
        public string HinhAnhBaiViet { get; set; }
        [DisplayName("Ngày Đăng")]
        public DateTime NgayDang { get; set; }
        [DisplayName("Người Đăng")]
        public string TenNguoiDang { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageDetailFile { get; set; }
    }
}