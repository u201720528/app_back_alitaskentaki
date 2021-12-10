using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUsuario
    {
        public int idusuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string documentoidentidad { get; set; }
        public string nombres { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
    }
}
