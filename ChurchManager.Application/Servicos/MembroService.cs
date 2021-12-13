using ChurchManager.Domain.Interfaces.Repositorios;

namespace ChurchManager.Application.Servicos
{
    public class MembroService : IMembroService
    {
        private IMembroRepositorio _membroRepositorio;

        public MembroService(IMembroRepositorio membroRepositorio)
        {
            _membroRepositorio = membroRepositorio;
        }

        public bool ValidarSeCPFDoMembroJaFoiCadastrado(string cpf)
        {
            var membroExistente = _membroRepositorio.FindBy(m => m.CPF == cpf);

            foreach (var item in membroExistente)
            {
                if (item.CPF == cpf) return true;
            }

            return false;
        }
    }
}