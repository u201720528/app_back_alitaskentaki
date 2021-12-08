using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse
    {
        public int idusuario { get; set; }
        public string documentoidentidad { get; set; }
        public string token { get; set; }
    }
}
