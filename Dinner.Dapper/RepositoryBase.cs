using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Dapper
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        DataBaseConfig dataConn = DataBaseConfig.GetInstance();
        public async Task Delete(T entity, string sql)
        {
            using (IDbConnection conn = dataConn.GetSqlConnection())
            {
                await conn.ExecuteAsync(sql, entity);
            }
        }

        public Task<T> Detail(T entity, string sql)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ExecQuery(string name)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T entity, string sql)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Select(string sql)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity, string sql)
        {
            throw new NotImplementedException();
        }
    }
}
