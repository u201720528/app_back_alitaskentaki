using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityAdminPedido : EntityBase
    {
        public int idpedido { get; set; }
        public int idusuario { get; set; }
        public int idmetodopago { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public EntityUsuario usuario { get; set; }
        public List<EntityAdminDetallePedido> detallePedido { get; set; }

    }
}
