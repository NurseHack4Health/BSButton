using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSButton.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
        private  IServiceCollection _services { get; set; }
        private  IConfiguration _config { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServiceCollection services, IConfiguration config)
            : base(options)
        {
            _services = services;
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        config.GetConnectionString("DefaultConnection")));
            _config = config;
        }
    }
}
