using Edu4TechBankEL.Entities;
using Edu4TechBankEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.InterfacesOfManagers
{
    public interface IBankAccountsManager: IBaseManager<BankAccounts, BankAccountsDTO,  int>
    {
    }
}
