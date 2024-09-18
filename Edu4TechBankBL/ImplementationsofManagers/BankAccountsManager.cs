using Edu4TechBankBL.InterfacesOfManagers;
using Edu4TechBankDL.ContextInfo;
using Edu4TechBankEL.Entities;
using Edu4TechBankEL.ViewModels;
using AutoMapper;
using Edu4TechBankBL.ImplementationofManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.ImplementationofManagers
{
    public class BankAccountsManager : BaseManager<BankAccounts, BankAccountsDTO, int>, IBankAccountsManager
    {
        public BankAccountsManager(MyContext ctx, IMapper mapper) : base(ctx, mapper)
        {

        }
    }
}
