using ChurchManager.Domain.Interfaces.Repositorios;

namespace ChurchManager.Application.Servicos
{
    public interface IIgrejaService
    {
        bool CnpjJaFoiCadastrado(string cnpj, IIgrejaRepositorio _igrejaRepositorio);
        bool MatrizJaFoiCadastrada(IIgrejaRepositorio _igrejaRepositorio);
    }
}