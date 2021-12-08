using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
namespace DBContext
{
    public class CarritoRepository : BaseRepository, ICarritoRepository
    {
        public BaseResponse ObtenerCarritoPorUsuario(int idUsuario)
        {
            var returnEntity = new BaseResponse();
            var entitiesCarrito = new List<EntityCarrito>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_CarritoComprasPorUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: idUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesCarrito = db.Query<EntityCarrito>(sql,
                       commandType: CommandType.StoredProcedure, param: p).ToList();
                    if (entitiesCarrito.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesCarrito;
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = null;
                    }

                }
            }
            catch (Exception ex)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }
    }
}
