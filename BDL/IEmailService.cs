using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDL
{
    public interface IEmailService
    {
        void Send(string targetEmail, string subject, string message);

    }


}
