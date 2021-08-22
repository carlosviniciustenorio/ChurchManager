using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Application.Servicos
{
    public class IgrejaService : IIgrejaService
    {
        public bool MatrizJaFoiCadastrada(IIgrejaRepositorio _igrejaRepositorio)
        {
            var matriz = _igrejaRepositorio.FindBy(i => i.Matriz == true);

            foreach (var item in matriz)
            {
                if (item.Matriz == true)
                    return true;
            }

            return false;

        }

        public bool CnpjJaFoiCadastrado(string cnpj, IIgrejaRepositorio _igrejaRepositorio)
        {
            var cnpjExistente = _igrejaRepositorio.FindBy(i => i.Cnpj == cnpj);

            foreach (var item in cnpjExistente)
            {
                if (item.Cnpj == cnpj)
                    return true;
            }

            return false;
        }
    }
}