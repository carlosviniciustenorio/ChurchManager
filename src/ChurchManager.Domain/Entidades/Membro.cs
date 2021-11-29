using ChurchManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChurchManager.Domain.Entidades
{
    public class Membro
    {
        #region Propriedades
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string Foto { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }
        public EstadoCivil EstadoCivil { get; private set; }
        public DateTime DataDeCasamento { get; private set; }
        public string NomeConjuge { get; private set; }
        public DateTime DataDeNascimentoConjuge { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public DateTime DataDoBatismo { get; private set; }
        public string IgrejaAnterior { get; private set; }
        public int IgrejaId { get; private set; }
        public Igreja Igreja { get; private set; }
        public string NomeDoPastorAnterior { get; private set; }
        public Funcao Funcao { get; private set; }
        public Status Status { get; private set; }

        #endregion

        #region Construtor
        public Membro(string nome, DateTime dataDeNascimento, Sexo sexo, string RG, string CPF,
            string nomePai, string nomeMae, EstadoCivil estadoCivil, DateTime dataDeCasamento, string nomeConjuge,
            DateTime dataDeNascimentoConjuge, string endereco, string email, string telefone, string celular, DateTime dataDoBatismo,
            string igrejaAnterior, int IgrejaId, string nomeDoPastorAnterior, Funcao funcao, Status status, string foto)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            this.RG = RG;
            this.CPF = CPF;
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
            this.IgrejaId = IgrejaId;
            NomeDoPastorAnterior = nomeDoPastorAnterior;
            Funcao = funcao;
            Status = status;
            Foto = foto;
        }

        public Membro(Membro membro)
        {
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
            Endereco = membro.Endereco;
            Email = membro.Email;
            Telefone = membro.Telefone;
            Celular = membro.Celular;
            DataDoBatismo = membro.DataDoBatismo;
            IgrejaAnterior = membro.IgrejaAnterior;
            IgrejaId = membro.IgrejaId;
            NomeDoPastorAnterior = membro.NomeDoPastorAnterior;
            Funcao = membro.Funcao;
            Status = membro.Status;
            Foto = membro.Foto;
        }
        #endregion

        #region Métodos Públicos
        public void AtualizarMembro(Membro membro)
        {
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
            Endereco = membro.Endereco;
            Email = membro.Email;
            Telefone = membro.Telefone;
            Celular = membro.Celular;
            DataDoBatismo = membro.DataDoBatismo;
            IgrejaAnterior = membro.IgrejaAnterior;
            IgrejaId = membro.IgrejaId;
            NomeDoPastorAnterior = membro.NomeDoPastorAnterior;
            Funcao = membro.Funcao;
            Status = membro.Status;
            Foto = membro.Foto;
        }

        public void AlterarEstadoCivil(EstadoCivil estadoCivil)
        {
            EstadoCivil = estadoCivil;
        }
        #endregion
    }
}
