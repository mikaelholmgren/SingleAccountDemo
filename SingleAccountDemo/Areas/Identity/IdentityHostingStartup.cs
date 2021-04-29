using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingleAccountDemo.Areas.Identity.Data;
using SingleAccountDemo.Data;

[assembly: HostingStartup(typeof(SingleAccountDemo.Areas.Identity.IdentityHostingStartup))]
namespace SingleAccountDemo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SingleAccountDemoContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SingleAccountDemoContextConnection")));

                services.AddDefaultIdentity<SingleAccountDemoUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SingleAccountDemoContext>();
            });
        }
    }
}