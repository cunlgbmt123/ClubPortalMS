using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.HoatDong
{
    public class QLDSHoatDongViewModel
    {
        public int ID { get; set; }
        public string ChuDe { get; set; }
        public string Mota { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public string NoiDung { get; set; }
        public string DiaDiem { get; set; }
        public string TenFile { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
        public string TenCLB { get; set; }
        public string LoaiHD { get; set; }
    }
}