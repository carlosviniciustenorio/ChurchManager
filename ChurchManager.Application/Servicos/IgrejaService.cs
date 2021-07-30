using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Application.Servicos
{
    public class IgrejaService : IIgrejaService
    {
        public bool MatrizJaFoiCadastrada(IUnitOfWork _unitOfWork)
        {
            var matriz = _unitOfWork.RepositorioIgreja.FindBy(i => i.Matriz == true);

            foreach (var item in matriz)
            {
                if (item.Matriz == true)
                    return true;
            }

            return false;

        }

        public bool CnpjJaFoiCadastrado(string cnpj, IUnitOfWork _unitOfWork)
        {
            var cnpjExistente = _unitOfWork.RepositorioIgreja.FindBy(i => i.Cnpj == cnpj);

            foreach (var item in cnpjExistente)
            {
                if (item.Cnpj == cnpj)
                    return true;
            }

            return false;
        }
    }
}