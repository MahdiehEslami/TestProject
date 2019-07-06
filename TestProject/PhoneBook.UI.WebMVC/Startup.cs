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
            services.AddScoped<IPersonService,PersonService>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();
            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("AAA")));
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
