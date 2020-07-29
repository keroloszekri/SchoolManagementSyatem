namespace Computony.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Number");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "Address");
        }
    }
}
