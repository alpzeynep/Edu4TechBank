using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.Entities
{
    [Table("BankAccounts")]
    public class BankAccounts : IBaseEntity<int>
    {
        [Key]
        public int Id {get;set; }
        public String UserId { get;set; }
        public int BankAccTypeId { get;set; }
        public String Iban { get;set; }
        public int Balance { get;set; }
        public DateTime CreatedDate { get;set; }
        public bool IsDeleted { get;set; }

        [ForeignKey("BankAccTypeId")]
        public virtual BankAccType BankAccType { get; set; }
    }
}
