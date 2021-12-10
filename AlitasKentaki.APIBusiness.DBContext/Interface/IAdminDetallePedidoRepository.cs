using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IAdminDetallePedidoRepository
    {
        public BaseResponse obtenerDetallePedidoPorPedido(int idpedido);

    }
}
