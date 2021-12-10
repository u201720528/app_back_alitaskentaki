using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {

        public BaseResponse obtenerUsuarioPorCodigo(int idusuario)
        {
            var returnEntity = new BaseResponse();
            var entityProject = new EntityUsuario();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerUsuarioPorCodigo";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: idusuario, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityProject = db.Query<EntityUsuario>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityProject != null)
                    {
                        returnEntity.issuccess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = entityProject;

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
            catch (Exception e)
            {
                returnEntity.issuccess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = e.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
        public BaseResponse obtenerUsuario(int idusuario)
        {
            throw new NotImplementedException();
        }

    }
}
