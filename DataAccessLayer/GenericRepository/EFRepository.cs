using CRUDDemo.DataAccessLayer.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo.DataAccessLayer.GenericRepository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly UserDbContext _dbContext;
        private readonly IConfiguration _config;

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(_config["AppSettings:ConnectionString"]);
            }
        }

        public IHttpContextAccessor Accessor { get; }

        public EfRepository(UserDbContext dbContext, IHttpContextAccessor accessor, IConfiguration config)
        {
            _dbContext = dbContext;
            Accessor = accessor;
            _config = config;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            CommitChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            CommitChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await CommitChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            await CommitChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task AddRangeAsync(IList<T> entity)
        {
            _dbContext.Set<T>().AddRange(entity);
            await CommitChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            CommitChanges();
        }

        public async Task UpdateRangeAsync(IList<T> entity)
        {
            _dbContext.Set<T>().UpdateRange(entity);
            await CommitChangesAsync();
        }

        public async Task DeleteRangeAsync(IList<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            await CommitChangesAsync();
        }

        public async Task<int> CommitChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual T EditWithChildren(T entity)
        {
            _dbContext.Attach(entity);
            IEnumerable<EntityEntry> unchangedEntities = _dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Unchanged);

            foreach (EntityEntry ee in unchangedEntities.ToList())
            {
                ee.State = EntityState.Modified;
            }

            return entity;
        }

        public int CommitChanges()
        {
            return _dbContext.SaveChanges();
        }

    }
}
