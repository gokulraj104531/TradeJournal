using Microsoft.EntityFrameworkCore;
using TradingJournal.Data;
using TradingJournal.Models;
using TradingJournal.Repoistories.Interfaces;

namespace TradingJournal.Repoistories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> dbset;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbset = _dbContext.Set<T>();
        }



        public void Updates(T entity)
        {
            dbset.Update(entity);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            List<T> list = dbset.ToList();
            return list;
        }

    }
}
