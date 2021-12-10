using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProductoRepository
    {
        public BaseResponse ObtenerProductosPorCategoria(int idCategoria);
        public BaseResponse ObtenerProductoPorId(int idProducto);

        // CAMBIOS MH
        public BaseResponse Crear(EntityProducto producto);
        public BaseResponse Actualizar(EntityProducto producto);
        public BaseResponse Desactivar(int codigo, int usuarioModifica);

        //F
        public BaseResponse ObtenerProductos();

    }
}
