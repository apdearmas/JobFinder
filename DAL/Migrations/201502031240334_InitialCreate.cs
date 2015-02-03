using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace DAL.Migrations
{
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
                .ForeignKey("dbo.ContactPersons", t => t.ContactPerson_Id)
                .Index(t => t.ContactPerson_Id);

            AddPredefinedCustomers();
            AddPredefinedJobOffers();

            SeedMembership();
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "ContactPerson_Id", "dbo.ContactPersons");
            DropIndex("dbo.JobOffers", new[] { "ContactPerson_Id" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactPersons");
        }

        private void AddPredefinedCustomers()
        {
            Sql("INSERT INTO Customers Values ('Antonio Pereira', 'apdermas@yahoo.com')");
            Sql("INSERT INTO Customers Values ('Frank Gongora', 'fgongora67@yahoo.com')");
        }

        private void AddPredefinedJobOffers()
        {
            Sql("INSERT INTO ContactPersons Values ('Empleador', 'xxx@yahoo.com', '00000000000')");
            Sql("INSERT INTO JobOffers Values ('01/01/2015', '01/07/2015', 'Job Offer', 1)");
        }
        private void SeedMembership()
        {
            AuthConfig.RegisterAuth();
            
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("epereira", false) == null)
            {
                membership.CreateUserAndAccount("epereira", "epereira");
            }
            if (!roles.GetRolesForUser("epereira").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "epereira" }, new[] { "Admin" });
            }
        }
    }
}
