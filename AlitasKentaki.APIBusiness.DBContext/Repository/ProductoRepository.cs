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

        //cambios mh
        public BaseResponse Crear(EntityProducto producto)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"DML_Producto_Ins";
                    var p = new DynamicParameters();

                    p.Add(name: "@id", value: producto.Codigo, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@Nombre", value: producto.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Precio", value: producto.Precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@IdCategoria", value: producto.IdCategoria, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Imagen", value: producto.Imagen, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Descripcion", value: producto.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@UsuarioModifica", value: producto.UsuarioCrea, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityProducto>(sql,
                      commandType: CommandType.StoredProcedure, param: p).FirstOrDefault();

                    int idGenerado = p.Get<int>("@id");
                    if (idGenerado > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idGenerado,
                            nombre = producto.Nombre
                        };
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0002";
                        returnEntity.errormessage = "Error desconocido";
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

        public BaseResponse Actualizar(EntityProducto producto)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"DML_Producto_UpdxPK";
                    var p = new DynamicParameters();

                    p.Add(name: "@id", value: producto.Codigo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Nombre", value: producto.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Precio", value: producto.Precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@IdCategoria", value: producto.IdCategoria, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Imagen", value: producto.Imagen, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Descripcion", value: producto.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@UsuarioModifica", value: producto.UsuarioModifica, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityProducto>(sql,
                      commandType: CommandType.StoredProcedure, param: p).FirstOrDefault();

                    int idGenerado = producto.Codigo;
                    returnEntity.issuccess = true;
                    returnEntity.errorcode = "0000";
                    returnEntity.errormessage = string.Empty;
                    returnEntity.data = new
                    {
                        id = idGenerado,
                        nombre = producto.Nombre
                    };

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

        public BaseResponse Desactivar(int codigo, int usuarioModifica)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"DML_Producto_DelxPK";
                    var p = new DynamicParameters();

                    p.Add(name: "@id", value: codigo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@UsuarioModifica", value: usuarioModifica, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityProducto>(sql,
                      commandType: CommandType.StoredProcedure, param: p).FirstOrDefault();

                    int idGenerado = p.Get<int>("@id");
                    if (idGenerado > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idGenerado

                        };
                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0002";
                        returnEntity.errormessage = "Error desconocido";
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

        public BaseResponse ObtenerProductos()
        {
            var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityProducto>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProductos";
                    entitiesProject = db.Query<EntityProducto>(sql, commandType: CommandType.StoredProcedure).ToList();
                    if (entitiesProject.Count > 0)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entitiesProject;
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
