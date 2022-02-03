using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.DataAccessLayer.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        T Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        T EditWithChildren(T Entity);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task UpdateRangeAsync(IList<T> Entity);

        Task DeleteAsync(T Entity);
        Task DeleteRangeAsync(IList<T> Entity);
    }
}
