using System;
using System.IO;
using System.Text;
using XSystem.Security.Cryptography;

namespace ChurchManager.Domain.Entidades
{
    public sealed class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string nome, string email, string senha) => (Nome, Email, Senha) = (nome, email, EncodePassword(senha));

        private static string EncodePassword(string password)
        {
            string result;
            var bytes = Encoding.Unicode.GetBytes(password);

            using (var stream = new MemoryStream())
            {
                stream.WriteByte(0);

                using (var sha256 = new SHA256Managed())
                {
                    var hash = sha256.ComputeHash(bytes);
                    stream.Write(hash, 0, hash.Length);

                    bytes = stream.ToArray();
                    result = Convert.ToBase64String(bytes);
                }

            }
            return result;
        }
    }
}
