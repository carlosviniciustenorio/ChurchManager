using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Domain.Token
{
    public sealed class JsonWebToken
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public string TokenType { get; set; } = "bearer";
        public long ExpiresIn { get; set; }
    }
}
