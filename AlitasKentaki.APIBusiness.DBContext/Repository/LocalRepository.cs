using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class LocalRepository : BaseRepository, ILocalRepository
    {
        public BaseResponse ObtenerLocales()
        {
            var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityLocal>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarLocale";
                    entitiesProject = db.Query<EntityLocal>(sql, commandType: CommandType.StoredProcedure).ToList();
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
