using ChurchManager.Application.Enums;
using System;

namespace ChurchManager.Application.Commands.AddMembro
{
    public class MembroInputModel
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
    }
}
