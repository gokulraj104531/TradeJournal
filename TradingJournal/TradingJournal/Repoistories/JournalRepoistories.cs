using TradingJournal.Data;
using TradingJournal.Models;

namespace TradingJournal.Repoistories
{
    public class JournalRepoistories
    {
        private readonly ApplicationDbContext _dbcontext;

        public JournalRepoistories(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddTrade(Journal journal)
        {
            try
            {
                _dbcontext.journals.Add(journal);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTrade(Journal journal) {
            try
            {
                _dbcontext.journals.Update(journal);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteTrade(int id) {
            try
            {
                Journal journal = _dbcontext.journals.Find(id);
                if (journal != null)
                {
                    _dbcontext.Remove(journal);
                    _dbcontext.SaveChanges();
                }
                else
                {
                    System.Console.WriteLine("Trade Not Found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Journal> GetJournals() {
            try
            {
                List<Journal> journals = _dbcontext.journals.ToList();
                return journals;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Journal> GetJournalbyUserName(string userName)
        {
           return _dbcontext.journals.Where(x=>x.UserName == userName).ToList();
        }


    }
}
