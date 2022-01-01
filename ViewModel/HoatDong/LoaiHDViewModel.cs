using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.HoatDong
{
    public class LoaiHDViewModel
    {
        public int ID { get; set; }
        [DisplayName("Loại Hoạt Động")]
        public string TenLoaiHD { get; set; }
    }
}