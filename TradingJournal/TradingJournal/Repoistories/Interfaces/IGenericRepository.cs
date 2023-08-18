using Microsoft.EntityFrameworkCore;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        
        void Updates(T entity);

        List<T> GetAll();
       
    }
}
