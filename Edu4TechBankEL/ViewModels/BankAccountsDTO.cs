using Edu4TechBankEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.ViewModels
{
    public class BankAccountsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BankAccTypeId { get; set; }
        public int Iban { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public  BankAccTypeDTO BankAccType { get; set; }
    }
}
