using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Commands.AddUsuario;
using ChurchManager.Application.Queries.GetIgrejas;
using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //UoW
            services.AddScoped<IUnitOfWork, ChurchManager.Infrastructure.Persistencia.UnitOfWork.UnitOfWork>();
            services.AddScoped<IUnitOfWorkLicenciado, ChurchManager.Infrastructure.Persistencia.UnitOfWork.UnitOfWorkLicenciado>();

            //Repositorios
            services.AddScoped<IIgrejaRepositorio, IgrejaRepositorio>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IMembroService, ChurchManager.Application.Servicos.MembroService>();
            services.AddScoped<IIgrejaService, ChurchManager.Application.Servicos.IgrejaService>();

            //Commands
            services.AddMediatR(typeof(AddMembroCommand));
            services.AddMediatR(typeof(AddIgrejaCommand.Command));

            //Queries
            services.AddMediatR(typeof(GetMembrosQuery));
            services.AddMediatR(typeof(GetIgrejasQuery));

            return services;
        }

    }
}
