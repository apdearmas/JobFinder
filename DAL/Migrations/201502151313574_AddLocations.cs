namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.JobOffers", "Title", c => c.String());
            AddColumn("dbo.JobOffers", "Location_Id", c => c.Int());
            CreateIndex("dbo.JobOffers", "Location_Id");
            AddForeignKey("dbo.JobOffers", "Location_Id", "dbo.Locations", "Id");

            UpdateJobOffers();
        }

        private void UpdateJobOffers()
        {
           Sql("INSERT INTO Locations Values ( 'Miami', 'Fl',33018)");
           Sql(string.Format("UPDATE JobOffers SET [Title] = 'Mecanico' , [Location_Id] = 1 WHERE Id BETWEEN {0} AND {1}", 1, 299));
           Sql(string.Format("UPDATE JobOffers SET [Title] = 'Doctor'   , [Location_Id] = 1 WHERE Id BETWEEN {0} AND {1}", 300, 699));
           Sql(string.Format("UPDATE JobOffers SET [Title] = 'Maestro'  , [Location_Id] = 1 WHERE Id BETWEEN {0} AND {1}", 700, 1000));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "Location_Id", "dbo.Locations");
            DropIndex("dbo.JobOffers", new[] { "Location_Id" });
            DropColumn("dbo.JobOffers", "Location_Id");
            DropColumn("dbo.JobOffers", "Title");
            DropTable("dbo.Locations");
        }
    }
}
