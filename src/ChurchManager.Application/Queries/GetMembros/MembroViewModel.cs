using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChurchManager.Application.Queries.GetMembros
{
    public class MembroViewModel
    {
        public MembroViewModel()
        { }

        public MembroViewModel(Membro membro, string erroMessage = "erro")
        {
            ID = membro.ID;
            Nome = membro.Nome;
            DataDeNascimento = membro.DataDeNascimento;
            Sexo = membro.Sexo;
            RG = membro.RG;
            CPF = membro.CPF;
            NomePai = membro.NomePai;
            NomeMae = membro.NomeMae;
            EstadoCivil = membro.EstadoCivil;
            DataDeCasamento = membro.DataDeCasamento;
            NomeConjuge = membro.NomeConjuge;
            DataDeNascimentoConjuge = membro.DataDeNascimentoConjuge;
            Email = membro.Email;
            Endereco = membro.Endereco;
            Telefone = membro.Telefone;
            Celular = membro.Celular;
            DataDoBatismo = membro.DataDoBatismo;
            IgrejaAnterior = membro.IgrejaAnterior;
            IgrejaId = membro.IgrejaId;
            NomeDoPastorAnterior = membro.NomeDoPastorAnterior;
            Funcao = membro.Funcao;
            Status = membro.Status;
            Foto = membro.Foto;
            ErrorMessage = erroMessage;
        }

        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Display(Name = "RG")]
        public string RG { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Nome do Pai")]
        public string NomePai { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Data de Casamento")]
        public DateTime DataDeCasamento { get; set; }

        [Display(Name = "Nome do Conjuge")]
        public string NomeConjuge { get; set; }

        [Display(Name = "Data de Nascimento do Conjuge")]
        public DateTime DataDeNascimentoConjuge { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Data do Batismo")]
        public DateTime DataDoBatismo { get; set; }

        [Display(Name = "Igreja Aonde Congregava")]
        public string IgrejaAnterior { get; set; }

        [Display(Name = "Igreja")]
        public Igreja Igreja { get; set; }

        [Display(Name = "Igreja")]
        public int IgrejaId { get; set; }

        [Display(Name = "Nome do Pastor")]
        public string NomeDoPastorAnterior { get; set; }

        [Display(Name = "Função")]
        public Funcao Funcao { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }

        public string ErrorMessage { get; set; }
    }
}
