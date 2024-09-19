using AutoMapper.Extensions.ExpressionMapping;
using DocumentFormat.OpenXml.Spreadsheet;
using Edu4TechBankBL.EmailSenderProcess;
using Edu4TechBankBL.ImplementationofManagers;
using Edu4TechBankBL.ImplementationsofManagers;
using Edu4TechBankBL.InterfacesOfManagers;
using Edu4TechBankDL.ContextInfo;
using Edu4TechBankEL.Entities;
using Edu4TechBankEL.IdentityModels;
using Edu4TechBankEL.ViewModels;
using Edu4TechBankWebUI.CreateDefaultData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Edu4TechBankWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        
     

            builder.Services.AddDbContext< MyContext >(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ZeynepAlp"));
                // options.UseSqlServer(builder.Configuration.GetConnectionString("BetülHoca"));

            });
            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
      
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();




            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                opt.ExpireTimeSpan = TimeSpan.FromHours(1);
                opt.LoginPath = "/Account/Login";
                opt.AccessDeniedPath = "/Account/Login";
                opt.SlidingExpiration = true;

            });
            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddExpressionMapping();
                opt.AddProfile(typeof(Maps));
            });

            builder.Services.AddScoped<IEmailManager, EmailManager>();
            builder.Services.AddScoped<IUserAddressManager , UserAddressManager>();
            builder.Services.AddScoped<IBankAccountsManager, BankAccountsManager>();
            builder.Services.AddScoped<IBankAccTypeManager, BankAccTypeManager>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var appScope = app.Services.CreateScope())
            {
               var serviceProvider = appScope.ServiceProvider;

               var roleManager =
                    serviceProvider.GetRequiredService<RoleManager<AppRole>>(); var emailManager=
                   serviceProvider.GetRequiredService<IEmailManager>();
               CreatedData createdData = new CreatedData();
                createdData.CreateAllRoles(roleManager, emailManager);

            }

                app.Run();
        }
    }
}