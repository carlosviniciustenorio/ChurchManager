using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Domain.Licenciados
{
    public class Licenciado
    {
        public int ID { get; private set; }
        public string Nome { get; set; }
        public string NomeCurto { get; set; }
        public string Apelido { get; set; }
        public string CodigoCidade { get; set; }
        public bool Suspenso { get; set; }
        public InfoBD BD { get; set; }
        public string CodArea { get; set; }
        public string CodPais { get; set; }
        public string Telefone { get; set; }

    }
}
