using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public BaseResponse ObtenerCategorias()
        {
            var returnEntity = new BaseResponse();

            return returnEntity;
        }
    }
}
