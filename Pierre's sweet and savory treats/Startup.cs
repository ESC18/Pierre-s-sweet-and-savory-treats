using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Data;
using Microsoft.AspNetCore.Identity;

namespace PierreTreats
{
    public class Startup
    {
        // ... Other configurations

        public void ConfigureServices(IServiceCollection services)
        {
            // ... Other services

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ... Other configurations

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
