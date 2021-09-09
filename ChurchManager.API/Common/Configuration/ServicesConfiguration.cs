using ChurchManager.API.Extensions;
using ChurchManager.Domain.Settings;
using ChurchManager.Infrastructure.Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                .AddDbContext<IdDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<LicenciadosDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("LicenciadosConnection")))
                .AddInfrastructure()
                .AddApplication()
                .AddControllers();

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<IdDbContext>();

            //JWT
            var appSettingsSection = configuration.GetSection("Setting");
            services.Configure<Setting>(appSettingsSection);

            var appSettings = appSettingsSection.Get<Setting>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });
        }
    }
}
