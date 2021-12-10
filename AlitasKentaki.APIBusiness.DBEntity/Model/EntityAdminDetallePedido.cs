using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityAdminDetallePedido
    {
        public int iddetallepedido { get; set; }
        public int idpedido { get; set; }
        public int idproducto { get; set; }
        public string cantidad { get; set; }
        public decimal precio { get; set; }
        public EntityProducto producto { get; set; }

    }
}
