using ClubPortalMS.ViewModel.CLB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.ThongBao
{
    public class ThongBaosViewModels
    {
        public int ID { get; set; }
        [DisplayName("Tiêu Đề")]
        public string TieuDe { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("CLB")]
        public string CLB { get; set; }
        [DisplayName("Ngày Thông Báo")]
        public DateTime NgayThongBao { get; set; }
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }
        [DisplayName("Tên File")]
        public string TenFile { get; set; }
        public string ContentType { get; set; }
        [DisplayName("Tệp đính kèm")]
        public byte[] File { get; set; }

       public int IdCLB { get; set; }
    }
}