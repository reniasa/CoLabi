namespace CoLabi.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.Equipment",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   IsAvailable = c.Boolean(),
                   IsOperational = c.Boolean(),
                   WorkingFrom = c.DateTime(),
                   WorkingTo = c.DateTime(),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Equipment");
        }
    }
}
