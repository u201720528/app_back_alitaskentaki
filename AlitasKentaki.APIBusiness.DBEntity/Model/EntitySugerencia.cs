using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntitySugerencia : EntityBase
    {
        public int Codigo { get; set; }
        public string Nombre{ get; set; }
        public string Correo { get; set; }
        public string TipoConsulta { get; set; }
        public string Consulta { get; set; }
        
    }
}