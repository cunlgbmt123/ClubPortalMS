namespace ClubPortalMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {

        public override void Up()
        {

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
                                IDUser = c.String(nullable: false, maxLength: 128),
                                CLB_ID = c.Int(),
                            })
                            .PrimaryKey(t => new { t.ID })
                            .ForeignKey("dbo.CLBs", t => t.CLB_ID)
                            .ForeignKey("dbo.AspNetUsers", t => t.IDUser, cascadeDelete: true)
                            .Index(t => t.CLB_ID)
                            .Index(t => t.IDUser);


            CreateTable(
               "dbo.NhiemVus",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   TieuDe = c.String(),
                   MoTa = c.String(),
                   IdCLB = c.Int(),
                   IdThanhVien = c.Int(),
                   ThanhVien_ID = c.Int(nullable: false),
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

        }

        public override void Down()
        {

        }
    }
}
