using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Dapper
{
    public interface IRepositoryBase<T>
    {
        Task Insert(T entity, string sql);
        Task Update(T entity, string sql);
        Task Delete(T entity, string sql);
        Task<List<T>> Select(string sql);
        Task<T> Detail(T entity, string sql);
        Task<List<T>> ExecQuery(string name);
    }
}
