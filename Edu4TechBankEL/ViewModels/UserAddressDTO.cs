using Edu4TechBankEL.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.ViewModels
{
    public class UserAddressDTO
    { 
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string FullAddress { get; set; }

        public bool IsDeleted { get; set; }

        //AppUserDTO olmamasının nedeni identity microsofttan otomatik geliyor 
        public AppUser? User { get; set; }
    }
}
