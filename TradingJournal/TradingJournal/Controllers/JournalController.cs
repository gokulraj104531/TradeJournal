using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Services;

namespace TradingJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly JournalServices journalServices;

        public JournalController(JournalServices journalServices)
        {
            this.journalServices = journalServices;
        }

        [HttpPost]
        [Route("AddTrade")]

        public IActionResult AddTrade(JournalDTO journalDTO)
        {
            try
            {
                journalServices.AddTradeServices(journalDTO);
                return StatusCode(200, journalDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetTradeDetails")]
        public List<JournalDTO> GetJournals()
        {
            try
            {
                return journalServices.GetJournalServices();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("EditTrade")]
        public IActionResult EditTrade(JournalDTO journalDTO)
        {
            try
            {
                journalServices.UpdateTradeServices(journalDTO);
                return StatusCode(200, journalDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DelteTrade/{id}")]
        public void Delete(int id)
        {
            try
            {
                journalServices.DeleteTradeServices(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
