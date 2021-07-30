using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChurchManager.Application.Entidades
{
    public class Igreja
    {
        #region Propriedades
        public int ID { get; private set; }
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string RazaoSocial { get; private set; }
        public bool Ativa { get; private set; }
        public bool Matriz { get; private set; }
        public string Endereco { get; private set; }
        public string Cep { get; private set; }
        public int DirigenteId { get; private set; }
        public Membro Dirigente { get; private set; }

        #endregion

        #region Construtores

        public Igreja(string cnpj, string nome, string razaoSocial, string endereco, string cep, bool ativa = true, bool matriz = false)
        {
            Cnpj = cnpj;
            Nome = nome;
            RazaoSocial = razaoSocial;
            Endereco = endereco;
            Cep = cep;
            Ativa = ativa;
            Matriz = matriz;
        }

        public Igreja(Igreja igreja)
        {
            Cnpj = igreja.Cnpj;
            Nome = igreja.Nome;
            RazaoSocial = igreja.RazaoSocial;
            Ativa = igreja.Ativa;
            Endereco = igreja.Endereco;
            Cep = igreja.Cep;
            DirigenteId = igreja.DirigenteId;
            Matriz = igreja.Matriz;
        }

        #endregion

        #region Métodos Públicos
        public void EditarIgreja(string cnpj, string nome, string razaoSocial, string endereco, string cep, int dirigente, bool ativa = true, bool matriz = false)
        {
            Cnpj = cnpj;
            Nome = nome;
            RazaoSocial = razaoSocial;
            Endereco = endereco;
            Cep = cep;
            DirigenteId = dirigente;
            Ativa = ativa;
            Matriz = matriz;
        }

        public void AdicionarDirigente(int IdDirigente)
        {
            DirigenteId = IdDirigente;
        }

        #endregion
    }
}
