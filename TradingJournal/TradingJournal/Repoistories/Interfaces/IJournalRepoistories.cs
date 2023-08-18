using TradingJournal.Models;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IJournalRepoistories:IGenericRepository<Journal>
    {
        void AddTrade(Journal journal);
       
        void DeleteTrade(int id);

        List<Journal> GetJournalbyUserName(string userName);

        List<Journal> GetJournalByid(int id);
    }
}
