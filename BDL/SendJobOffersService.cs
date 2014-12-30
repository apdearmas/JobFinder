using System.Linq;
using System.Windows.Forms;

namespace BDL
{
    
    public class SendJobOffersService : ISendJobOffersService
    {
        private ICustomerService customerService;
        private IJobOffersService jobOffersService;
        private IEmailService emailService;

        public SendJobOffersService(ICustomerService customerService, IJobOffersService jobOffersService, IEmailService emailService)
        {
            this.customerService = customerService;
            this.jobOffersService = jobOffersService;
            this.emailService = emailService;
        }

        public void SendJobOffers()
        {
            var customers = customerService.FindAll();
            var jobOffers = jobOffersService.FindAll();

            foreach (var customer in customers)
            {
                emailService.Send(customer.EMail,"","");
            }
        }


    }
}