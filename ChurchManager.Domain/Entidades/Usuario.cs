namespace ChurchManager.Domain.Entidades
{
    public sealed class Usuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string email, string senha) => (Email, Senha) = (email, Helpers.PasswordHelper.EncodePassword(senha));
    }
}
