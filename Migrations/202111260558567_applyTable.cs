namespace ClubPortalMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        Video = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CLBs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdLoaiCLB = c.Int(),
                        TenCLB = c.String(),
                        TrangThai = c.String(),
                        NgayThanhLap = c.DateTime(),
                        LienHe = c.String(),
                        FanPage = c.String(),
                        SDT = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiCLBs", t => t.IdLoaiCLB)
                .Index(t => t.IdLoaiCLB);
            
            CreateTable(
                "dbo.DangKies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        MSSV = c.String(),
                        Email = c.String(),
                        SDT = c.String(),
                        NgayDangKy = c.DateTime(),
                        TrangThai = c.String(),
                        IdCLB = c.Int(),
                        CLB_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .Index(t => t.CLB_ID);
            
            CreateTable(
                "dbo.ChoXetDuyets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDNguoiDK = c.Int(),
                        TrangThai = c.String(),
                        DangKy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DangKies", t => t.DangKy_ID)
                .Index(t => t.DangKy_ID);
            
            CreateTable(
                "dbo.GioiThieux",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCLB = c.Int(),
                        MoTa = c.String(),
                        HinhAnh = c.Binary(),
                        LichSuHinhThanh = c.String(),
                        CLB_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .Index(t => t.CLB_ID);
            
            CreateTable(
                "dbo.LoaiCLBs",
                c => new
                    {
                        IDLoaiCLB = c.Int(nullable: false, identity: true),
                        TenLoaiCLB = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiCLB);
            
            CreateTable(
                "dbo.PhanHois",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        NoiDung = c.String(),
                        Email = c.String(),
                        SDT = c.String(),
                        DiaChi = c.String(),
                        IdCLB = c.Int(),
                        CLB_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .Index(t => t.CLB_ID);
            
            CreateTable(
                "dbo.QLDSHoatDongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChuDe = c.String(),
                        NgayBatDau = c.DateTime(),
                        NgayKetThuc = c.DateTime(),
                        TrangThai = c.String(),
                        IdCLB = c.Int(),
                        IdLoaiHD = c.Int(),
                        CLB_ID = c.Int(),
                        LoaiHD_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .ForeignKey("dbo.LoaiHDs", t => t.LoaiHD_ID)
                .Index(t => t.CLB_ID)
                .Index(t => t.LoaiHD_ID);
            
            CreateTable(
                "dbo.LoaiHDs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoaiHD = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SuKiens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDeSK = c.String(),
                        NgayBatDau = c.DateTime(),
                        NgayKetThuc = c.DateTime(),
                        NoiDung = c.String(),
                        KetQua = c.String(),
                        DiaDiem = c.String(),
                        HinhThuc = c.String(),
                        IdLoaiSK = c.Int(),
                        IdCLB = c.Int(),
                        CLB_ID = c.Int(),
                        LoaiSuKien_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .ForeignKey("dbo.LoaiSuKiens", t => t.LoaiSuKien_ID)
                .Index(t => t.CLB_ID)
                .Index(t => t.LoaiSuKien_ID);
            
            CreateTable(
                "dbo.LoaiSuKiens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoaiSK = c.String(),
                        TrangThai = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ThanhViens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCLB = c.Int(),
                        Ten = c.String(),
                        NgaySinh = c.DateTime(),
                        MSSV = c.String(),
                        Lop = c.String(),
                        SDT = c.String(),
                        Mail = c.String(),
                        IDUser = c.String(),
                        CLB_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .Index(t => t.CLB_ID);
            
            CreateTable(
                "dbo.NhiemVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        MoTa = c.String(),
                        IdCLB = c.Int(),
                        IdThanhVien = c.Int(),
                        ThanhVien_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThanhViens", t => t.ThanhVien_ID)
                .Index(t => t.ThanhVien_ID);
            
            CreateTable(
                "dbo.TTNhatKies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdThanhVien = c.Int(),
                        TGThamGia = c.DateTime(),
                        SKDaThamGia = c.Int(),
                        ThanhVien_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThanhViens", t => t.ThanhVien_ID)
                .Index(t => t.ThanhVien_ID);
            
            CreateTable(
                "dbo.ThongBaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        MoTa = c.String(),
                        IdCLB = c.Int(),
                        NgayThongBao = c.DateTime(),
                        NoiDung = c.String(),
                        File = c.Binary(),
                        CLB_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                .Index(t => t.CLB_ID);
            
            CreateTable(
                "dbo.HoatDongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        MoTa = c.String(),
                        KeyWord = c.String(),
                        URL = c.String(),
                        NgayDang = c.DateTime(nullable: false),
                        TenNguoiDang = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LienHes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        DiaChi = c.String(),
                        HotLine = c.String(),
                        Email = c.String(),
                        Ten = c.String(),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenPoster = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        MoTa = c.String(),
                        KeyWord = c.String(),
                        URL = c.String(),
                        HinhAnhBaiViet = c.String(),
                        HinhAnhChiTiet = c.String(),
                        NgayDang = c.DateTime(nullable: false),
                        TenNguoiDang = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ThongBaos", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.TTNhatKies", "ThanhVien_ID", "dbo.ThanhViens");
            DropForeignKey("dbo.NhiemVus", "ThanhVien_ID", "dbo.ThanhViens");
            DropForeignKey("dbo.ThanhViens", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.SuKiens", "LoaiSuKien_ID", "dbo.LoaiSuKiens");
            DropForeignKey("dbo.SuKiens", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.QLDSHoatDongs", "LoaiHD_ID", "dbo.LoaiHDs");
            DropForeignKey("dbo.QLDSHoatDongs", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.PhanHois", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.CLBs", "IdLoaiCLB", "dbo.LoaiCLBs");
            DropForeignKey("dbo.GioiThieux", "CLB_ID", "dbo.CLBs");
            DropForeignKey("dbo.ChoXetDuyets", "DangKy_ID", "dbo.DangKies");
            DropForeignKey("dbo.DangKies", "CLB_ID", "dbo.CLBs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ThongBaos", new[] { "CLB_ID" });
            DropIndex("dbo.TTNhatKies", new[] { "ThanhVien_ID" });
            DropIndex("dbo.NhiemVus", new[] { "ThanhVien_ID" });
            DropIndex("dbo.ThanhViens", new[] { "CLB_ID" });
            DropIndex("dbo.SuKiens", new[] { "LoaiSuKien_ID" });
            DropIndex("dbo.SuKiens", new[] { "CLB_ID" });
            DropIndex("dbo.QLDSHoatDongs", new[] { "LoaiHD_ID" });
            DropIndex("dbo.QLDSHoatDongs", new[] { "CLB_ID" });
            DropIndex("dbo.PhanHois", new[] { "CLB_ID" });
            DropIndex("dbo.GioiThieux", new[] { "CLB_ID" });
            DropIndex("dbo.ChoXetDuyets", new[] { "DangKy_ID" });
            DropIndex("dbo.DangKies", new[] { "CLB_ID" });
            DropIndex("dbo.CLBs", new[] { "IdLoaiCLB" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TinTucs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posters");
            DropTable("dbo.LienHes");
            DropTable("dbo.HoatDongs");
            DropTable("dbo.ThongBaos");
            DropTable("dbo.TTNhatKies");
            DropTable("dbo.NhiemVus");
            DropTable("dbo.ThanhViens");
            DropTable("dbo.LoaiSuKiens");
            DropTable("dbo.SuKiens");
            DropTable("dbo.LoaiHDs");
            DropTable("dbo.QLDSHoatDongs");
            DropTable("dbo.PhanHois");
            DropTable("dbo.LoaiCLBs");
            DropTable("dbo.GioiThieux");
            DropTable("dbo.ChoXetDuyets");
            DropTable("dbo.DangKies");
            DropTable("dbo.CLBs");
            DropTable("dbo.Albums");
        }
    }
}
