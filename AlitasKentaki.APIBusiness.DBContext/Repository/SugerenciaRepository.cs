using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
namespace DBContext
{
    public class SugerencuaRepository : BaseRepository, ISugerenciaRepository
    {
        public BaseResponse AgregarSugerencia(EntitySugerencia entitySugerencia)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_InsertarSugerencia";
                    var p = new DynamicParameters();
                    p.Add(name: "@NOMBRE", value: entitySugerencia.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CORREO", value: entitySugerencia.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@TIPOCONSULTA", value: entitySugerencia.TipoConsulta, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONSULTA", value: entitySugerencia.Consulta, dbType: DbType.String, direction: ParameterDirection.Input);
                    db.Query<EntitySugerencia>(
                         sql: sql,
                         param: p,
                         commandType: CommandType.StoredProcedure
                         ).FirstOrDefault();

                    returnEntity.issuccess = true;
                    returnEntity.errorcode = "0000";
                    returnEntity.errormessage = string.Empty;
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
