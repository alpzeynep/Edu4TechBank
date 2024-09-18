using Microsoft.EntityFrameworkCore;
using Edu4TechBankEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Edu4TechBankEL.IdentityModels;

namespace Edu4TechBankDL.ContextInfo
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options)
      : base(options)
        {
        }

        public virtual DbSet< BankAccType> BankAccTypeTable {get;set;}
        public virtual DbSet<BankAccounts> BankAccountsTable { get; set; }
        public virtual DbSet<UserAddress> UserAddressTable { get; set; }

       
    }
}
