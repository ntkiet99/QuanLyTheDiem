namespace QuanLyTheDiemKH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoLot = c.String(),
                        Ten = c.String(),
                        TaiKhoan = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        DiaChi = c.String(),
                        NgayThamGia = c.DateTime(nullable: false),
                        DiemSo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhachHangs");
        }
    }
}
