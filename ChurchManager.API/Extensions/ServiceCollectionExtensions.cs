using ChurchManager.API.Filters;
using ChurchManager.Application.AuthHelper;
using ChurchManager.Application.Commands;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.Repositorios;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ChurchManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddSwagger(services);
            AddInfrastructure(services);
            AddApplication(services);
            AddAuthJWT(services, configuration);
            return services;
        }
        
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //Repositorios
            services.AddScoped<IIgrejaRepositorio, IgrejaRepositorio>();
            services.AddScoped<IMembroRepositorio, MembroRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }

        public static void AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IMembroService, MembroService>();
            services.AddScoped<IIgrejaService, IgrejaService>();

            //Commands
            services.AddMediatR(Assembly.GetAssembly(typeof(AddMembroCommand.Command)));

            //FluentValidation
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddIgrejaCommand.Validator>());
        }

        public static void AddSwagger(this IServiceCollection services)
        {
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChurchManager API", Version = "v1", Description = "doing" });
                c.OperationFilter<AuthorizationOperationFilter>();
                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            });
        }

        public static void AddAuthJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = services.BuildServiceProvider().GetRequiredService<JwtSetupData>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("ECDsa", x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        RequireSignedTokens = true,
                        RequireExpirationTime = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = ECDsaSecurity.ObterECDsaPublica(),
                    };
                });
        }

    }
}
