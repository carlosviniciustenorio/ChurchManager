using ChurchManager.API.Extensions;
using ChurchManager.API.Filters;
using ChurchManager.Domain.Settings;
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

            //Swagger
            var schemaIdRegex = new Regex(@"(\w*\.)*");

            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Coloque o TOKEN abaixo. Em ambiente dev, utilize @usuario para logar como qualquer usuario",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.CustomSchemaIds(x => schemaIdRegex.Replace(x.FullName!, "").Replace("+", "."));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DiverPay API", Version = "v1", Description = "testando" });
                c.OperationFilter<AuthorizationOperationFilter>();
                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            });
        }
    }
}
