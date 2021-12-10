using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ICarritoRepository
    {
        public BaseResponse ObtenerCarritoPorUsuario(int idUsuario);
        public BaseResponse ObtenerMontoCarritoPorUsuario(int idUsuario);
        public BaseResponse AgregarPedidoCarrito(int idUsuario);
        public BaseResponse AgregarProductoCarrito(EntityProductoCarrito entityProductoCarrito);
    }
}
