namespace Computony.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubCats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cats", t => t.CatID, cascadeDelete: true)
                .Index(t => t.CatID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SubCatID = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubCats", t => t.SubCatID, cascadeDelete: true)
                .Index(t => t.SubCatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SubCatID", "dbo.SubCats");
            DropForeignKey("dbo.SubCats", "CatID", "dbo.Cats");
            DropIndex("dbo.Students", new[] { "SubCatID" });
            DropIndex("dbo.SubCats", new[] { "CatID" });
            DropTable("dbo.Students");
            DropTable("dbo.SubCats");
            DropTable("dbo.Cats");
        }
    }
}
