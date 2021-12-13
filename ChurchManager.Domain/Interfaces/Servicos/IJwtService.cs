using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Domain.Interfaces.Servicos
{
    public interface IJwtService
    {
        JsonWebToken CreateJsonWebToken(Usuario user);
    }
}
