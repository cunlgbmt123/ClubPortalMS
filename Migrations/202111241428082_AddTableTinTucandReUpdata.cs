namespace ClubPortalMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTinTucandReUpdata : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.HoatDongs", "NgayDang", c => c.DateTime(nullable: false));
            AddColumn("dbo.HoatDongs", "TenNguoiDang", c => c.String());
            AddColumn("dbo.LienHes", "Ten", c => c.String());
            AddColumn("dbo.LienHes", "NoiDung", c => c.String());
            AddColumn("dbo.Posters", "Status", c => c.Boolean());
            DropColumn("dbo.HoatDongs", "HinhAnhChiTiet");
            DropColumn("dbo.HoatDongs", "HinhAnhBaiViet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoatDongs", "HinhAnhBaiViet", c => c.Binary());
            AddColumn("dbo.HoatDongs", "HinhAnhChiTiet", c => c.Binary());
            DropColumn("dbo.Posters", "Status");
            DropColumn("dbo.LienHes", "NoiDung");
            DropColumn("dbo.LienHes", "Ten");
            DropColumn("dbo.HoatDongs", "TenNguoiDang");
            DropColumn("dbo.HoatDongs", "NgayDang");
            DropTable("dbo.TinTucs");
        }
    }
}
