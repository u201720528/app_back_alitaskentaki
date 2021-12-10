using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class AdminPedidoRepository : BaseRepository, IAdminPedidoRepository
    {
        public BaseResponse ObtenerAdminPedidos()
        {
            var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityAdminPedido>();
            var usuarioRepository = new UsuarioRepository();
            var detallePedidoRepository = new AdminDetallePedidoRepository();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarAdminPedidos";
                    entitiesProject = db.Query<EntityAdminPedido>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                       ).ToList();

                    if (entitiesProject.Count > 0)
                    {
                        foreach (var project in entitiesProject)
                        {
                            project.usuario = (EntityUsuario)usuarioRepository.obtenerUsuarioPorCodigo(project.idusuario).data;
                            project.detallePedido = detallePedidoRepository.obtenerDetallePedidoPorPedido(project.idpedido).data
                                as List<EntityAdminDetallePedido>;

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

        public BaseResponse ObtenerAdminPedidoPorUsuarioYPedido(int idusuario, int idpedido)
        {
            var returnEntity = new BaseResponse();
            var entityProject = new EntityAdminPedido();
            var usuarioRepository = new UsuarioRepository();
            var detallePedidoRepository = new AdminDetallePedidoRepository();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarAdminPedido_Usuario_Y_Pedido";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: idusuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPEDIDO", value: idpedido, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityProject = db.Query<EntityAdminPedido>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (idusuario > 0 && idpedido > 0)
                    {
                        entityProject.usuario = (EntityUsuario)usuarioRepository.obtenerUsuarioPorCodigo(idusuario).data;
                        entityProject.detallePedido = detallePedidoRepository.obtenerDetallePedidoPorPedido(idpedido).data
                                as List<EntityAdminDetallePedido>;

                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = String.Empty;
                        returnEntity.data = entityProject;

                    }
                    else
                    {
                        returnEntity.issuccess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = String.Empty;
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

        public BaseResponse ObtenerAdminPedidosPorUsuario(int idusuario)
        {
            throw new NotImplementedException();
        }
    }
}
