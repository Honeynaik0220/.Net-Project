using Dapper;
using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class SP_CALL : ISP_CALL
    {
        private readonly ApplicationDbContext _context;
        private static string ConnectionString = "";
        public SP_CALL(ApplicationDbContext context)
        {
            _context = context;
            ConnectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                SqlCon.Open();
                SqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T>List<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                SqlCon.Open();
                return SqlCon.Query<T>(ProcedureName, param,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                SqlCon.Open();
                var result = SqlCon.QueryMultiple(ProcedureName, param,
                    commandType: CommandType.StoredProcedure);
                var item1 = result.Read<T1>();
                var item2 = result.Read<T2>();
                if (item1 != null && item2 != null)
                    return new Tuple <IEnumerable<T1>,IEnumerable<T2>> (item1, item2);
                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>
                    (new List<T1>(),new List<T2>());
            }

        }

        public T OneRecord<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                SqlCon.Open();
                var value = SqlCon.Query<T>(ProcedureName, param,
                    commandType: CommandType.StoredProcedure);
                return value.FirstOrDefault();
            }
        }

        public T Single<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                SqlCon.Open();
                return SqlCon.ExecuteScalar<T>(ProcedureName, param,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
