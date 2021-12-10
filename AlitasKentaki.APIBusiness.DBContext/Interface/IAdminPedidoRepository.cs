using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IAdminPedidoRepository
    {
        public BaseResponse ObtenerAdminPedidos();
        public BaseResponse ObtenerAdminPedidoPorIdpedido(int idpedido);
        public BaseResponse ObtenerAdminPedidosPorUsuario(int idusuario);
        public BaseResponse ObtenerAdminPedidoPorUsuarioYPedido(int idusuario, int pedido);
        public BaseResponse ModificarEstado(int idpedido);

    }
}
