using TradingJournal.DTO;
using TradingJournal.Models;
namespace TradingJournal.Services.Interfaces
{
    public interface IJournalServices
    {
        void AddTradeServices(JournalDTO journalDTO);
        void UpdateTradeServices(JournalDTO journalDTO);
        List<JournalDTO> GetJournalByIdServices(int id);
        void DeleteTradeServices(int id);
        List<JournalDTO> GetJournalServices();
        List<JournalDTO> GetJournalDTOs(string UserName);
        double Profit(string userName);
        int TradeCount(string userName);
        int ProfitPercent(string userName);
        List<ProfitorLossDTO> LineChart(string userName);

    }
}
