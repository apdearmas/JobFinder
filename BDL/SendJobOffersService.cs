using System.Linq;
using System.Windows.Forms;

namespace BDL
{
    
    public class SendJobOffersService : ISendJobOffersService
    {
        private ICustomerService customerService;
        private IJobOffersService jobOffersService;

        public SendJobOffersService(ICustomerService customerService, IJobOffersService jobOffersService)
        {
            this.customerService = customerService;
            this.jobOffersService = jobOffersService;
        }

        public void SendJobOffers()
        {
            var customers = customerService.FindAll();
            var jobOffers = jobOffersService.FindAll();

            MessageBox.Show(jobOffers.First().Description);
        }
    }
}