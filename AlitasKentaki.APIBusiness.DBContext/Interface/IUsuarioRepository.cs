using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IUsuarioRepository
    {
        public BaseResponse obtenerUsuario(int idusuario);
        public BaseResponse obtenerUsuarioPorCodigo(int idusuario);
    }
}
