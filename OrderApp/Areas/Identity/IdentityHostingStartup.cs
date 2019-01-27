using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Areas.Identity.Data;
using OrderApp.Models;

[assembly: HostingStartup(typeof(OrderApp.Areas.Identity.IdentityHostingStartup))]
namespace OrderApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<OrderAppUser>()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}