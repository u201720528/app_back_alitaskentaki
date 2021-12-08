using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCarrito : EntityBase
    {
        public int Codigo { get; set; }
        public string Nombre{ get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
}
