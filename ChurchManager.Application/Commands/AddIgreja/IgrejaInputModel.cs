namespace ChurchManager.Application.Commands.AddIgreja
{
    public class IgrejaInputModel
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public bool Ativa { get; set; }
        public bool Matriz { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public int DirigenteId { get; set; }
    }
}
