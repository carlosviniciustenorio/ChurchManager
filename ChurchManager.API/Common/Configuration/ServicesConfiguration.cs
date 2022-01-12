using ChurchManager.API.Extensions;
using ChurchManager.API.Filters;
using ChurchManager.Infrastructure.Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace ChurchManager.API.Common.Configuration
{
    public static class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApiServices(services, configuration);
        }

        private static void ConfigureApiServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<CmDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<LicenciadosDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("LicenciadosConnection")))
                .AddDependencies(configuration);
        }
    }
}
