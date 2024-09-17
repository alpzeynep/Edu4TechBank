using DocumentFormat.OpenXml.Bibliography;
using Edu4TechBankEL.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.Entities
{
    [Table("UserAddress")]
    public class UserAddress : IBaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string FullAddress { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
