using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.TinTuc
{
    public class TinTucViewModel
    {
        public TinTucViewModel()
        {
            
            HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/TinTuc/addImg.jpg";
            HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/TinTuc/addImg.jpg";
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn chưa tiêu đề")]
        [DisplayName("Tiêu Đề")]
        public string TieuDe { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        [DisplayName("Mô Tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [DisplayName("Nội Dung")]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        public string NoiDung { get; set; }
        public string KeyWord { get; set; }
        public string URL { get; set; }
        [DisplayName("Hình ảnh bài viết")]
        [Required(ErrorMessage = "Hình ảnh bài viết đang trống")]
        public string HinhAnhBaiViet { get; set; }
        [Required(ErrorMessage = "Hình ảnh chi tiết đang trống")]
        [DisplayName("Hình Ảnh Chi tiết")]
        public string HinhAnhChiTiet { get; set; }
        [DisplayName("Ngày Đăng")]
        public DateTime NgayDang { get; set; }
        [DisplayName("Người Đăng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tác giả")]
        public string TenNguoiDang { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageDetailFile { get; set; }
    }
}