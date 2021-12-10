using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class AdminDetallePedidoRepository : BaseRepository, IAdminDetallePedidoRepository
    {
        public BaseResponse obtenerDetallePedidoPorPedido(int idpedido)
        {
            var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityAdminDetallePedido>();
            var productoRepository = new ProductoRepository();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_DetallePedido_X_Pedido";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", value: idpedido, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entitiesProject = db.Query<EntityAdminDetallePedido>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                       ).ToList();

                    if (entitiesProject.Count > 0)
                    {
                        foreach (var project in entitiesProject)
                        {
                            project.producto = (EntityProducto)productoRepository.ObtenerProductoPorId(project.idproducto).data;

                        }

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