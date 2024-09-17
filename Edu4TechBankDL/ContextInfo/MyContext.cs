using Microsoft.EntityFrameworkCore;
using Edu4TechBankEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankDL.ContextInfo
{
    public class MyContext : DbContext
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
    }
}
