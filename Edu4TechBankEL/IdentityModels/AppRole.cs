using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu4TechBankEL.IdentityModels
{
    public class AppRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
