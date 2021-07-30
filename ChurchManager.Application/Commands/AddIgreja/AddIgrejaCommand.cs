using MediatR;

namespace ChurchManager.Application.Commands.AddIgreja
{
    public class AddIgrejaCommand : IRequest<Unit>
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public bool Ativa { get; set; }
        public bool Matriz { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public int DirigenteId { get; set; }

        public AddIgrejaCommand(IgrejaInputModel obj)
        {
            Cnpj = obj.Cnpj;
            Nome = obj.Nome;
            RazaoSocial = obj.RazaoSocial;
            Ativa = obj.Ativa;
            Endereco = obj.Endereco;
            Cep = obj.Cep;
            DirigenteId = obj.DirigenteId;
            Matriz = obj.Matriz;
        }
    }
}
