using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubPortalMS.ViewModel.Sukien
{
    public class SuKiensViewModel
    {
        public int ID { get; set; }
        public string TieuDeSK { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiDung { get; set; }
        public string KetQua { get; set; }
        public string DiaDiem { get; set; }
        public string HinhThuc { get; set; }
        public string TenFile { get; set; }
        public string ContentType { get; set; }

        public byte[] File { get; set; }
        public string LoaiSK { get; set; }
        public string CLB { get; set; }
    }
}