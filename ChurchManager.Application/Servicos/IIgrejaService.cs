using ChurchManager.Infrastructure.Persistencia.UnitOfWork;

namespace ChurchManager.Application.Servicos
{
    public interface IIgrejaService
    {
        bool CnpjJaFoiCadastrado(string cnpj, IUnitOfWork _unitOfWork);
        bool MatrizJaFoiCadastrada(IUnitOfWork _unitOfWork);
    }
}