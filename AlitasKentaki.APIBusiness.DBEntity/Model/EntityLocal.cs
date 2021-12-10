using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLocal : EntityBase
    {
        public int Codigo { get; set; }
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

    }
}