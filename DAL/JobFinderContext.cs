using System.Data.Entity;
using BusinessDomain;

namespace DAL
{
    public class JobFinderContext : DbContext
    {
        public JobFinderContext()
            : base("name = JobFinderConnection")
        {
        }

        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
    }
}
