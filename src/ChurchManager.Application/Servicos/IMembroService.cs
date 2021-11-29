namespace ChurchManager.Application.Servicos
{
    public interface IMembroService
    {
        bool ValidarSeCPFDoMembroJaFoiCadastrado(string cpf);
    }
}
