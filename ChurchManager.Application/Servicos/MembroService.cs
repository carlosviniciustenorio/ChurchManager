using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

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