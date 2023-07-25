using AutoMapper;
using TradingJournal.Data;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Repoistories;
using TradingJournal.Repoistories.Interfaces;
using TradingJournal.Services.Interfaces;

namespace TradingJournal.Services
{
    public class JournalServices : IJournalServices
    {
        private readonly IJournalRepoistories journalRepoistories;
        private readonly IMapper _mapper;
        public JournalServices(IJournalRepoistories _journalRepoistories, IMapper mapper)
        {
            journalRepoistories = _journalRepoistories;
            _mapper = mapper;
        }

        public void AddTradeServices(JournalDTO journalDTO) {
            try
            {
                Journal journal = _mapper.Map<Journal>(journalDTO);
                journalRepoistories.AddTrade(journal);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpdateTradeServices(JournalDTO journalDTO)
        {
            try
            {
                Journal journal = _mapper.Map<Journal>(journalDTO);
                journalRepoistories.UpdateTrade(journal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTradeServices(int id)
        {
            try
            {
                journalRepoistories.DeleteTrade(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JournalDTO> GetJournalServices()
        {
            try
            {
                var journal = journalRepoistories.GetJournals();
                List<JournalDTO> journalDTOs = _mapper.Map<List<JournalDTO>>(journal);
                return journalDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JournalDTO> GetJournalDTOs(string UserName)
        {
            try
            {
                var tradejournal = journalRepoistories.GetJournalbyUserName(UserName);
                List<JournalDTO> journalDTOs = _mapper.Map<List<JournalDTO>>(tradejournal);
                return journalDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double Profit(string userName)
        {
            try
            {
                var TotalSalaryMS = journalRepoistories.GetJournalbyUserName(userName)
                              .Sum(x => x.ProfitorLoss);
                return (double)TotalSalaryMS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int TradeCount(string userName)
        {
            try
            {
                var totalCount = journalRepoistories.GetJournalbyUserName(userName).Count();
                return totalCount;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ProfitPercent(string userName) {
            try
            {
                var UserProfit = journalRepoistories.GetJournalbyUserName(userName).Sum(x => x.ProfitorLoss);
                double ProfitPercent = ((double)UserProfit / 10000) * 100;
                return (int)ProfitPercent;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<ProfitorLossDTO> LineChart(string userName)
        {
            try
            {
                var userdata = journalRepoistories.GetJournalbyUserName(userName);
                List<ProfitorLossDTO> profitorLossDTOs =_mapper.Map<List<ProfitorLossDTO>>(userdata);
                return profitorLossDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}












