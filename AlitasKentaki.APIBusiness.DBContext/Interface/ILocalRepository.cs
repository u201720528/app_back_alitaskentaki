using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ILocalRepository
    {
        public BaseResponse ObtenerLocales();
    }
}
