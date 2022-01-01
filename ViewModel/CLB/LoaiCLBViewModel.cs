using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.CLB
{
    public class LoaiCLBViewModel
    {
        public int IDLoaiCLB { get; set; }

        [DisplayName("Loại Câu Lạc Bộ")]
        public string TenLoaiCLB { get; set; }
    }
}