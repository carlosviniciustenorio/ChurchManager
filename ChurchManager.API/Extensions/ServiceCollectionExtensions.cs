using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Commands.AddUsuario;
using ChurchManager.Application.Queries.GetIgrejas;
using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, ChurchManager.Infrastructure.Persistencia.UnitOfWork.UnitOfWork>();
            services.AddScoped<IUnitOfWorkLicenciado, ChurchManager.Infrastructure.Persistencia.UnitOfWork.UnitOfWorkLicenciado>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IMembroService, ChurchManager.Application.Servicos.MembroService>();
            services.AddScoped<IIgrejaService, ChurchManager.Application.Servicos.IgrejaService>();

            //Commands
            services.AddMediatR(typeof(AddMembroCommand));
            services.AddMediatR(typeof(AddIgrejaCommand));

            //Queries
            services.AddMediatR(typeof(GetMembrosQuery));
            services.AddMediatR(typeof(GetIgrejasQuery));

            return services;
        }

    }
}
