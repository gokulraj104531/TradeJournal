using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Services;
using TradingJournal.Services.Interfaces;

namespace TradingJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalServices journalServices;

        public JournalController(IJournalServices journalServices)
        {
            this.journalServices = journalServices;
        }

        [HttpPost]
        [Route("AddTrade")]
        public void AddTrade(JournalDTO journalDTO)
        {
            try
            {
                journalServices.AddTradeServices(journalDTO);
                // return StatusCode(200, journalDTO);
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


        [HttpGet]
        [Route("GetTradeDetailsByID/{id}")]
        public List<JournalDTO> GetJournalById(int id)
        {
            try
            {
                return journalServices.GetJournalByIdServices(id);
            }
            catch (Exception)
            {

                throw;
            }
        }





        [HttpGet]
        [Route("GetTradeDetails/{UserName}")]
        public List<JournalDTO> GetTradeDetails(string UserName) {
            try
            {
                return journalServices.GetJournalDTOs(UserName);
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
        [Route("DeleteTrade/{id}")]
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

        [HttpGet]
        [Route("Profit/{username}")]
        public double GetProfit(string username) {
            try
            {
                return journalServices.Profit(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("TotalCount/{username}")]
        public int GetProfitCount(string username)
        {
            try
            {
                return journalServices.TradeCount(username);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("ProfitPercent/{username}")]
        public double ProfitPercent(string  username)
        {
            try
            {
                return journalServices.ProfitPercent(username);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("LineChart/{username}")]
        public List<ProfitorLossDTO> Linechart(string username)
        {
            try
            {
                return journalServices.LineChart(username);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
