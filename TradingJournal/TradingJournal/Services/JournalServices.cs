using AutoMapper;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Repoistories.Interfaces;
using TradingJournal.Services.Interfaces;

namespace TradingJournal.Services
{
    public class JournalServices : IJournalServices
    {
        private readonly IJournalRepoistories journalRepoistories;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofwork;
        public JournalServices(IJournalRepoistories _journalRepoistories, IMapper mapper, IUnitofWork unitofwork)
        {
            journalRepoistories = _journalRepoistories;
            _mapper = mapper;
            _unitofwork = unitofwork;

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
                _unitofwork.JournalRepoistories.Updates(journal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JournalDTO> GetJournalByIdServices(int id) {
            try
            {
                var journaldata=journalRepoistories.GetJournalByid(id);
                List<JournalDTO> idjournalDTOs = _mapper.Map<List<JournalDTO>>(journaldata);
                return idjournalDTOs;

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
                var journal =_unitofwork.JournalRepoistories.GetAll();
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
                double ProfitPercent = (double)UserProfit / 10000 * 100;
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
                var userData = journalRepoistories.GetJournalbyUserName(userName);
                List<ProfitorLossDTO> profitorLossDTOs =_mapper.Map<List<ProfitorLossDTO>>(userData);
                return profitorLossDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}












