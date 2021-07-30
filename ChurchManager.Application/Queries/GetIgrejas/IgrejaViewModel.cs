using ChurchManager.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public class IgrejaViewModel
    {
        public IgrejaViewModel()
        {
        }

        public IgrejaViewModel(Igreja igreja, string erroMessage = "erro")
        {
            ID = igreja.ID;
            Cnpj = igreja.Cnpj;
            Nome = igreja.Nome;
            RazaoSocial = igreja.RazaoSocial;
            Ativa = igreja.Ativa;
            Endereco = igreja.Endereco;
            Cep = igreja.Cep;
            DirigenteId = igreja.DirigenteId;
            Matriz = igreja.Matriz;
            ErroMessage = erroMessage;
        }

        [Display(Name = "ID")]
        public int ID { get; private set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; private set; }

        [Display(Name = "Nome")]
        public string Nome { get; private set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; private set; }

        [Display(Name = "Ativa")]
        public bool Ativa { get; private set; }

        [Display(Name = "Matriz")]
        public bool Matriz { get; private set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; private set; }

        [Display(Name = "CEP")]
        public string Cep { get; private set; }

        [Display(Name = "ID Dirigente")]
        public int DirigenteId { get; private set; }

        [Display(Name = "Dirigente")]
        public Membro Dirigente { get; private set; }

        public string ErroMessage { get; private set; }
    }
}
