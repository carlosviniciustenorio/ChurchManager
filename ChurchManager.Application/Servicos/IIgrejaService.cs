using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;

namespace ChurchManager.Application.Servicos
{
    public interface IIgrejaService
    {
        bool CnpjJaFoiCadastrado(string cnpj, IIgrejaRepositorio _igrejaRepositorio);
        bool MatrizJaFoiCadastrada(IIgrejaRepositorio _igrejaRepositorio);
    }
}