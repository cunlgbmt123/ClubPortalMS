using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ClubPortalMS.ViewModel.Poster
{
    public class PosterViewModel
    {
        public PosterViewModel()
        {
            HinhAnh = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
        }
        public int ID { get; set; }
        [DisplayName("Tên Poster")]
        public string TenPoster { get; set; }
        [DisplayName("Hình Ảnh Tải Lên")]
        public string HinhAnh { get; set; }
        [DisplayName("Trạng Thái")]
        public bool Status { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
   
    }
}