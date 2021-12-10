using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ProductoRepository : BaseRepository, IProductoRepository
    {
        public BaseResponse ObtenerProductosPorCategoria(int idCategoria)
        {
            var returnEntity = new BaseResponse();
            var entitiesProducto = new List<EntityProducto>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProductosPorCategoria";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", value: idCategoria, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesProducto = db.Query<EntityProducto>(sql,
                       commandType: CommandType.StoredProcedure, param: p).ToList();
                    if (entitiesProducto.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesProducto;
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
        public BaseResponse ObtenerProductoPorId(int idProducto)
        {
            var returnEntity = new BaseResponse();
            var entitiesProducto = new List<EntityProducto>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProductoPorId";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: idProducto, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesProducto = db.Query<EntityProducto>(sql,
                       commandType: CommandType.StoredProcedure, param: p).ToList();
                    if (entitiesProducto.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesProducto[0];
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
