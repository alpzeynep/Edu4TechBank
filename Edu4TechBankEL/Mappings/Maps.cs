using Edu4TechBankEL.Entities;
using Edu4TechBankEL.ViewModels;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<BankAccType, BankAccTypeDTO>().ReverseMap();
            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
            CreateMap<BankAccType, BankAccTypeDTO>().ReverseMap();
        }
    }
}
//opt.CreateMap<BankAccType, BankAccTypeDTO>().ReverseMap();
//opt.CreateMap<BankAccounts, BankAccountsDTO>().ReverseMap();
//opt.CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
