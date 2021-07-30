using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Application.Servicos
{
    public class MembroService : IMembroService
    {
        private IUnitOfWork _unitOfWork;

        public MembroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ValidarSeCPFDoMembroJaFoiCadastrado(string cpf)
        {
            var membroExistente = _unitOfWork.RepositorioMembro.FindBy(m => m.CPF == cpf);

            foreach (var item in membroExistente)
            {
                if (item.CPF == cpf) return true;
            }

            return false;
        }
    }
}