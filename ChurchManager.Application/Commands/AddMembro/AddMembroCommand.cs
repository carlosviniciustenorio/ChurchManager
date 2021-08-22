using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Application.Commands.AddMembro
{
    public static class AddMembroCommand
    {
        public record Command(string Nome, DateTime DataDeNascimento, Sexo Sexo, string RG, string CPF,
            string NomePai, string NomeMae, EstadoCivil EstadoCivil, DateTime DataDeCasamento,
            string NomeConjuge, DateTime DataDeNascimentoConjuge, string Endereco, string Email,
            string Telefone, string Celular, DateTime DataDoBatismo, string IgrejaAnterior, int IdIgreja,
            string NomeDoPastorAnterior, Funcao Funcao, Status Status, string Foto) : IRequest<Unit>;

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("Nome não pode ser vazio");

                RuleFor(x => x.DataDeNascimento)
                    .NotEmpty().WithMessage("Data de Nascimento não pode ser vazia");

                RuleFor(x => x.Sexo)
                    .NotEmpty().WithMessage("Sexo não pode ser vazio");

                RuleFor(x => x.RG)
                    .NotEmpty().WithMessage("RG não pode ser vazio");

                RuleFor(x => x.CPF)
                    .NotEmpty().WithMessage("CPF não pode ser vazio");
            }
        }
        
    }
}
