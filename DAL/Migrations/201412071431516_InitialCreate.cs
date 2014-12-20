namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EMail = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ContactPerson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactPersons", t => t.ContactPerson_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "ContactPerson_Id", "dbo.ContactPersons");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactPersons");
        }
    }
}
