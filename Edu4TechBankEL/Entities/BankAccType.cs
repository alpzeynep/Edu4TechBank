using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.Entities
{
    [Table("BankAccType")]
    public class BankAccType: IBaseEntity<int>
    {
        [Key]
        public int Id { get;set; }
        public DateTime CreatedDate { get;set; }
        [Required]
        public string AccountType { get; set; }
        public bool IsDeleted { get;set; }
    }
}
