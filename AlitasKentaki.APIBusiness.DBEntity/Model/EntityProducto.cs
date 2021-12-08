using System;
using System.Collections.Generic;
using System.Text;


namespace DBEntity
{
    public class EntityProducto : EntityBase
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
