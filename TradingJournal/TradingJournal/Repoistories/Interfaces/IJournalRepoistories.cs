using TradingJournal.Models;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IJournalRepoistories
    {
        void AddTrade(Journal journal);
        void UpdateTrade(Journal journal);
        void DeleteTrade(int id);
        List<Journal> GetJournals();
        List<Journal> GetJournalbyUserName(string userName);
    }
}
