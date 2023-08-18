using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingJournal.Models
{
    public class Journal
    {
        [Key]
        public int journalId { get; set; }
        public  string? UserName { get; set; }

        public string? StockName { get; set; }

        public string? OrderType { get; set; }

        public int? Quantity { get; set; }

        public int? EntryPrice { get; set; }

        public DateTime EntryTime { get; set; } 

        public int? ClosePrice { get; set; }

        public DateTime CloseTime { get; set; }

        public int? ProfitorLoss { get; set; } 

        public string? JournalTrade { get; set; }

    
    }
}
