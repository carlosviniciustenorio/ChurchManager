using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Application.Commands.AddMembro
{
    public class AddMembroCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime DataDeCasamento { get; set; }
        public string NomeConjuge { get; set; }
        public DateTime DataDeNascimentoConjuge { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataDoBatismo { get; set; }
        public string IgrejaAnterior { get; set; }
        public int IgrejaId { get; set; }
        public string NomeDoPastorAnterior { get; set; }
        public Funcao Funcao { get; set; }
        public Status Status { get; set; }
        public string Foto { get; set; }

        public AddMembroCommand(string nome, DateTime dataDeNascimento, Sexo sexo, string rG, string cPF,
            string nomePai, string nomeMae, EstadoCivil estadoCivil, DateTime dataDeCasamento,
            string nomeConjuge, DateTime dataDeNascimentoConjuge, string endereco, string email,
            string telefone, string celular, DateTime dataDoBatismo, string igrejaAnterior, int igreja,
            string nomeDoPastorAnterior, Funcao funcao, Status status, string foto)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            RG = rG;
            CPF = cPF;
            NomePai = nomePai;
            NomeMae = nomeMae;
            EstadoCivil = estadoCivil;
            DataDeCasamento = dataDeCasamento;
            NomeConjuge = nomeConjuge;
            DataDeNascimentoConjuge = dataDeNascimentoConjuge;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            DataDoBatismo = dataDoBatismo;
            IgrejaAnterior = igrejaAnterior;
            IgrejaId = igreja;
            NomeDoPastorAnterior = nomeDoPastorAnterior;
            Funcao = funcao;
            Status = status;
            Foto = foto;
        }
    }
}
