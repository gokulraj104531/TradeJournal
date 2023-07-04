using AutoMapper;
using TradingJournal.Data;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Repoistories;

namespace TradingJournal.Services
{
    public class JournalServices
    {
        private readonly JournalRepoistories journalRepoistories;
        private readonly IMapper _mapper;
        public JournalServices(JournalRepoistories _journalRepoistories, IMapper mapper)
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
                List<JournalDTO> journalDTOs=_mapper.Map<List<JournalDTO>>(journal);
                return journalDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

