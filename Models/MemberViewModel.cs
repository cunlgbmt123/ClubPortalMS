using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubPortalMS.Models
{
    public class ProfileViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên")]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mã số sinh viên")]
        public string MSSV { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập lớp")]
        public string Lop { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại")]
        public string SDT { get; set; }
        public string HinhDaiDien { get; set; }
        public int? User_ID { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn khoa")]
        public int? Khoa_ID { get; set; }
        public string UserName { get; set; }
        public string TenKhoa { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập Email")]
        public string Email { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}