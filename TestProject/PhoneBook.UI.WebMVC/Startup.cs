using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phonbook.Core.Contracts.People;
using Phonbook.Core.Contracts.Phones;
using Phonbook.Core.Contracts.Tags;
using Phonebook.DAL.EF;
using Phonebook.DAL.EF.People;
using Phonebook.DAL.EF.Phones;
using Phonebook.DAL.EF.Tags;
using Phonebook.Services.ApplicationServices;
using PhoneBook.UI.WebMVC.Models.AAA;

namespace PhoneBook.UI.WebMVC
{
    public class Startup  
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PhoneBookContext>();
            services.AddScoped<IPersonRepository, EfPersonRepository>();
            services.AddScoped<ITagRepository, EfTagRepository>();
            services.AddScoped<IPhoneRepository, EfPhoneRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("AAA")));

            services.AddScoped<IUserValidator<AppUser>, MyUserValidator>();
            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidatorFull>();
            services.AddIdentity<AppUser, IdentityRole>(c =>
            {
                //c.User.AllowedUserNameCharacters = "jdjd";
                c.User.RequireUniqueEmail = true;
                c.Password.RequireDigit = false;
                c.Password.RequiredLength = 6;
                c.Password.RequireUppercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequiredUniqueChars = 1;
                c.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<UserDbContext>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
