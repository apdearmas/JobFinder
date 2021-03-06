﻿using System.Data.Entity;
using BusinessDomain;

namespace DAL
{
    public class JobFinderContext : DbContext
    {
        public JobFinderContext()
            : base("name = JobFinderContext")
        {
            Database.SetInitializer<JobFinderContext>(null);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
