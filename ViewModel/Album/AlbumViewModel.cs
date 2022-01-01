using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.Album
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            HinhAnh = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
            Video = "~/Areas/Admin/Resource/Video/addImg.jpg";
        }
        public int ID { get; set; }
        /*[DisplayName("Tiêu Đề")]*/
        public string TieuDe { get; set; }
        [DisplayName("Tải hình ảnh lên")]
        public string HinhAnh { get; set; }
        [DisplayName("Tải video lên")]
        public string Video { get; set; }
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoFile { get; set; }
    }
}