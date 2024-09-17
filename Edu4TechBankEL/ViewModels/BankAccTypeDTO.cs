using Edu4TechBankEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.ViewModels
{
    public class BankAccTypeDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
