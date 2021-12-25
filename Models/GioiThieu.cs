
namespace ClubPortalMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class GioiThieu
    {
        public GioiThieu()
        {
            HinhAnh = "~/Areas/Admin/Resource/HinhAnh/addImg.jpg";
            
        }
        
      
        public int ID { get; set; }
        public int IdCLB { get; set; }
        public string MoTa { get; set; }

        [DisplayName("Tải hình ảnh lên")]
        public string HinhAnh { get; set; }
        public string LichSuHinhThanh { get; set; }
        [ForeignKey("IdCLB")]
        public virtual CLB CLB { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
