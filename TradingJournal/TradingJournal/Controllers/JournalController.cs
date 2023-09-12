using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Services;
using TradingJournal.Services.Interfaces;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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


        [HttpGet("GeneratePdf/{UserName}")]
        public IActionResult GeneratePDF(string UserName)
        {
            var document = new PdfDocument();
            List<JournalDTO> journalEntries = journalServices.GetJournalDTOs(UserName);

            string htmlcontent = "<div style='width:100%; text-align:center'>";
            htmlcontent += "<h1>Trading Journal</h1>";

            if (journalEntries != null && journalEntries.Count > 0)
            {
                htmlcontent += "<table style='width:100%; border-collapse: collapse;'>";
                htmlcontent += "<tr><th colspan='9' style='border: 1px solid black;'>Journal Entries</th></tr>";
                htmlcontent += "<tr><th style='border: 1px solid black;'>Stock</th><th style='border: 1px solid black;'>Order Type</th><th style='border: 1px solid black;'>Quantity</th><th style='border: 1px solid black;'>Entry Price</th><th style='border: 1px solid black;'>Entry Time</th><th style='border: 1px solid black;'>Close Price</th><th style='border: 1px solid black;'>Close Time</th><th style='border: 1px solid black;'>Profit/Loss</th><th style='border: 1px solid black;'>Journal Trade</th></tr>";

                foreach (var journalEntry in journalEntries)
                {
                    htmlcontent += "<tr>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.StockName + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.OrderType + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.Quantity + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.EntryPrice + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.EntryTime + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.ClosePrice + "</td>";
                    htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.CloseTime + "</td>";

                    if (journalEntry.ProfitorLoss.HasValue)
                    {
                        htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.ProfitorLoss + "</td>";
                    }
                    else
                    {
                        htmlcontent += "<td style='border: 1px solid black;'></td>";
                    }

                    if (!string.IsNullOrEmpty(journalEntry.JournalTrade))
                    {
                        htmlcontent += "<td style='border: 1px solid black;'>" + journalEntry.JournalTrade + "</td>";
                    }
                    else
                    {
                        htmlcontent += "<td style='border: 1px solid black;'></td>";
                    }
                    htmlcontent += "</tr>";
                }
                htmlcontent += "</table>";
            }
            else
            {
                htmlcontent += "<p>No journal entries found.</p>";
            }

            htmlcontent += "</div>";

            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);

            byte[] response;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }

            string Filename = "Trading_journal_" + UserName + ".pdf";
            return File(response, "application/pdf", Filename);
        }


    }
}
