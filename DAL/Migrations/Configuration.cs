using System;
using System.Linq;
using System.Web.Security;
using BusinessDomain;
using WebMatrix.WebData;

namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JobFinderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "JobFinderContext";
        }

        protected override void Seed(JobFinderContext context)
        {
            var frank = new Customer {Name = "Frank Gongora", EMail = "fgongora67@yahoo.com"};
            var tony = new Customer { Name = "Antonio Pereira", EMail = "apdearmas@yahoo.com" };
            var jobOffer = new JobOffer{ 
                Description = "New Job Offer", 
                IssuedDate = DateTime.Now, 
                ExpirationDate = DateTime.Now.AddMonths(1),
                ContactPerson = new ContactPerson { Name = "Empleador", EMail = "xxx@yahoo.com", PhoneNumber = "00000000000"}
            };

            context.Customers.AddOrUpdate(frank);
            context.Customers.AddOrUpdate(tony);
            context.JobOffers.AddOrUpdate(jobOffer);
            context.SaveChanges();

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("JobFinderConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider) Roles.Provider;
            var membership = (SimpleMembershipProvider) Membership.Provider;
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
                roles.AddUsersToRoles(new [] {"epereira"}, new[] {"Admin"});
            }
        }
    }
}
