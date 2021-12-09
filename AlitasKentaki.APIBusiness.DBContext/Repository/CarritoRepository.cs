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
        public BaseResponse AgregarProductoCarrito(EntityProductoCarrito entityProductoCarrito)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_InsertarProyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@IDUSUARIO", value: entityProductoCarrito.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPRODUCTO", value: entityProductoCarrito.IdProducto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@CANTIDAD", value: entityProductoCarrito.Cantidad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    db.Query<EntityProductoCarrito>(
                         sql: sql,
                         param: p,
                         commandType: CommandType.StoredProcedure
                         ).FirstOrDefault();

                    int id = p.Get<int>("@ID");

                    returnEntity.issuccess = true;
                    returnEntity.errorcode = "0000";
                    returnEntity.errormessage = string.Empty;
                    returnEntity.data = id;
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

        public BaseResponse ObtenerMontoCarritoPorUsuario(int idUsuario)
        {
            var returnEntity = new BaseResponse();
            var entitiesCarrito = new List<EntityCarritoPago>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_MontoCarritoComprasPorUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: idUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesCarrito = db.Query<EntityCarritoPago>(sql,
                       commandType: CommandType.StoredProcedure, param: p).ToList();
                    if (entitiesCarrito.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesCarrito[0];
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
