using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ISugerenciaRepository
    {
        public BaseResponse AgregarSugerencia(EntitySugerencia entitySugerencia);
    }
}
