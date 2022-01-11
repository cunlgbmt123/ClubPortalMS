using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.HoatDong
{
    public class HoatDongsViewModel
    {
        public HoatDongsViewModel()
        {

            HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/HoatDong/addImg.jpg";
            HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/HoatDong/addImg.jpg";
        }
        public int ID { get; set; }
        [DisplayName("Tiêu Đề")]
        public string Ten { get; set; }
        [DisplayName("Mô Tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }
        public string KeyWord { get; set; }
        public string URL { get; set; }
        [DisplayName("Hình ảnh bài viết")]
        public string HinhAnhBaiViet { get; set; }
        [DisplayName("Hình Ảnh Chi tiết")]
        public string HinhAnhChiTiet { get; set; }
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