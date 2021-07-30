using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Domain.Settings
{
    public class Setting
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
