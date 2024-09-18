using AutoMapper;
using Edu4TechBankBL.ImplementationofManagers;
using Edu4TechBankBL.InterfacesOfManagers;
using Edu4TechBankDL.ContextInfo;
using Edu4TechBankEL.Entities;
using Edu4TechBankEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankBL.ImplementationsofManagers
{
    public class UserAddressManager: BaseManager<UserAddress,UserAddressDTO,int>, IUserAddressManager
    {
        public UserAddressManager(MyContext ctx, IMapper mapper) : base(ctx, mapper)
        {

        }
    }
}
