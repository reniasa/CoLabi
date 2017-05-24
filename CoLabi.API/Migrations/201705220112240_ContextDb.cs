namespace CoLabi.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        IsOperational = c.Boolean(nullable: false),
                        WorkingFrom = c.DateTime(nullable: false),
                        WorkingTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialization = c.String(),
                        LastOnline = c.DateTime()
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Equipments");
        }
    }
}
