using Microsoft.EntityFrameworkCore;
using TradingJournal.Data;
using TradingJournal.Repoistories.Interfaces;

namespace TradingJournal.Repoistories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> dbset;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbset = _dbContext.Set<T>();
        }

       //public void Deletes(T entity)
       // {
       //     var rem = dbset.Find(entity);
       //     dbset.Remove(rem);
       // }

        public void Updates(T  entity)
        {
            dbset.Update(entity);
            _dbContext.SaveChanges();
        }

      

    }
}
