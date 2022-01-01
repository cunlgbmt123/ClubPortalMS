using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.Khoa
{
    public class KhoaViewModel
    {
        public int ID { get; set; }
        [DisplayName("Tên Khoa")]
        public String TenKhoa { get; set; }
    }
}