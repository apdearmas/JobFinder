using System;

namespace BusinessDomain
{
    public class JobOffer
    {
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public ContactPerson ContactPerson { get; set; }
        
    }
}
