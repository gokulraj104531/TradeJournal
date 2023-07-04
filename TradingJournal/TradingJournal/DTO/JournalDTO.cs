using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TradingJournal.Models;

namespace TradingJournal.DTO
{
    public class JournalDTO
    {
        [Key]
        public int journalId { get; set; }

        [ForeignKey("UserRegistration")]
        public int UserId { get; set; }

        public virtual UserRegistration UserRegistration { get; set; }

        public string? StockName { get; set; }

        public string? OrderType { get; set; }

        public int Quantity { get; set; }

        public int EntryPrice { get; set; }

        public DateTime EntryTime { get; set; }

        public int ClosePrice { get; set; }

        public DateTime CloseTime { get; set; }

        public int? ProfitorLoss { get; set; }

        public string? JournalTrade { get; set; }

    }
}
