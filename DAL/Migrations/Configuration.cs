using System;
using BusinessDomain;

namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JobFinderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DAL.JobFinderContext";
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
        }
    }
}
