using ChurchManager.Application.AuthHelper;
using ChurchManager.Domain.Entidades;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Application.Servicos
{
    public class TokenService
    {
        public object SymetricSecurit { get; private set; }

        public string GerarECDsaAssymetric(Usuario usuario)
        {
            var signingCredentials = new SigningCredentials(ECDsaSecurity.ObterECDsaPrivada(), SecurityAlgorithms.EcdsaSha256);
            return GerarToken(signingCredentials, usuario);
        }
        private string GerarToken(SigningCredentials signIn, Usuario usuario)
        {
            DateTime Now = DateTime.Now;
            var Jwt = new SecurityTokenDescriptor
            {
                Issuer = "CManager",
                Audience = "church-manager-api",
                IssuedAt = Now,
                NotBefore = Now,
                Expires = Now.AddDays(20),
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, "string", ClaimValueTypes.Email)
                })
            };
            Jwt.SigningCredentials = signIn;

            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(Jwt);
        }
    }
}
