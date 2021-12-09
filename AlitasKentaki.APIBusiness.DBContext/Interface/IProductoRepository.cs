using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProductoRepository
    {
        public BaseResponse ObtenerProductosPorCategoria(int idCategoria);
    }
}
