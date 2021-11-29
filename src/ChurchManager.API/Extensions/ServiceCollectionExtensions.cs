using ChurchManager.Application.Commands;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ChurchManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //UoW
            services.AddScoped<IUnitOfWorkLicenciado, UnitOfWorkLicenciado>();

            //Repositorios
            services.AddScoped<IIgrejaRepositorio, IgrejaRepositorio>();
            services.AddScoped<IMembroRepositorio, MembroRepositorio>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IMembroService, MembroService>();
            services.AddScoped<IIgrejaService, IgrejaService>();

            //Commands
            services.AddMediatR(Assembly.GetAssembly(typeof(AddMembroCommand.Command)));

            //FluentValidation
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddIgrejaCommand.Validator>());

            return services;
        }

    }
}
