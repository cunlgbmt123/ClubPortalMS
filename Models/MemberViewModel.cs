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
        public string Ten { get; set; }
        public string Ho { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }
        public string MSSV { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string HinhDaiDien { get; set; }
        public int? User_ID { get; set; }
        public int? Khoa_ID { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}