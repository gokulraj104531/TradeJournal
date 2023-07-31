using Microsoft.EntityFrameworkCore;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        
       
        void Updates(T entity);
         
        //void Adds(T entity);

        List<T> GetAll();

        //void Deletes(T entity);
        //DbSet<T> GetEntities<T>() where T : class;

    }
}
