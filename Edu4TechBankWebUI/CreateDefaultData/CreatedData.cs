using Edu4TechBankBL.EmailSenderProcess;
using Edu4TechBankEL.AllEnums;
using Edu4TechBankEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Edu4TechBankWebUI.CreateDefaultData
{
    public class CreatedData
    {
        public void CreateAllRoles(RoleManager<AppRole> roleManager, IEmailManager emailManager) 
        {
            try 
            {
              

                var allRoleNames = Enum.GetNames(typeof(Roles));
                foreach(var item in allRoleNames)
                {
                    var result=roleManager.RoleExistsAsync(item).Result;
                    var result2= roleManager.RoleExistsAsync(item).Result;

                    if (!result)
                    {
                        AppRole role = new AppRole()
                        {
                            Description = $"Sistem tarafından {DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss.fff")} oluşturuldu!",
                            Name = item
                        };
                        var r = roleManager.CreateAsync(role).Result;
                        
                    }
                    //if(result==null)
                    //{
                    //    AppRole role = new AppRole()
                    //    {
                    //        Description = $"Sistem tarafından {DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss.fff")} oluşturuldu!",
                    //        Name = item
                    //    };
                    //    var r = roleManager.CreateAsync(role).Result;
                    //}
                }

            }
            catch (Exception ex) 
            {
            }
        }
    }
}
