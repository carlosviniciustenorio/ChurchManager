using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Application.AuthHelper
{
    public class JwtSetupData
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ValidForMinutes { get; }
        public int RefreshTokenValidForMinutes { get; }
        public SigningCredentials SigningCredentials { get; }

        public DateTime IssuedAt => DateTime.UtcNow;
        public DateTime NotBefore => IssuedAt;
        public DateTime AccessTokenExpiration => IssuedAt.AddMinutes(ValidForMinutes);
        public DateTime RefreshTokenExpiration => IssuedAt.AddMinutes(RefreshTokenValidForMinutes);

        public JwtSetupData(IConfiguration configuration)
        {
            Issuer = configuration["JwtData:Issuer"];
            Audience = configuration["JwtData:Audience"];
            ValidForMinutes = Convert.ToInt32(configuration["JwtData:ValidForMinutes"]);

            var signingKey = ECDsaSecurity.ObterECDsaPublica().ToString();
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
