using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubPortalMS.Models
{
    public class ViewModel1
    {
        public ThanhVien ThanhVien { get; set; }
        public CLB CLB { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
        public PhanHoi PhanHoi { get; set; }
        public QLDSHoatDong QLDSHoatDong { get; set; }
        public SuKien SuKien { get; set; }
        public NhiemVu NhiemVu { get; set; }
        public NhiemVu_ThanhVien NhiemVu_ThanhVien { get; set; }
        public DangKy DangKy { get; set; }
        public DkyCLB DkyCLB { get; set; }
        public LoaiCLB LoaiCLB { get; set; }
        public LichTap LichTap { get; set; }
        public LichTap_ThanhVien LichTap_ThanhVien { get; set; }
     

    }
    public class ViewModel2
    {
        public int IDCLB { get; set; }
        public string TenCLB { get; set; }
    }
    public class ViewModel3
    {
        public int IDCLB { get; set; }
        public string TenCLB { get; set; }
        public string Mota { get; set; }
        public DateTime? NgayThanhLap { get; set; }
    }
    public class PhanHoiCLBViewModel
    {
        public int IdTvien { get; set; }
        public int IdCLB { get; set; }
        public string TenCLB { get; set; }
    }
    public class DiemDanhCLBViewModel
    {
        public int ID { get; set; }
        public bool DiemDanh { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
    }

    public class ThongBaoViewModel
    {
        public CLB CLB { get; set; }
        public ThongBao ThongBao { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
    }
    public class HoatDongViewModel
    {
        public CLB CLB { get; set; }
        public QLDSHoatDong QLDSHoatDong { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
    }
    public class SukienViewModel
    {
        public CLB CLB { get; set; }
        public SuKien SuKien { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
    }
    public class NhiemVuViewModel
    {
        public CLB CLB { get; set; }
        public NhiemVu NhiemVu { get; set; }
        public ThanhVien_CLB ThanhVien_CLB { get; set; }
    }
    
}