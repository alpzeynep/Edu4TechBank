using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.EmailSenderProcess
{
    public interface IEmailManager
    {
        bool SendEmail(EmailMessageModel model);
        
    }
}
