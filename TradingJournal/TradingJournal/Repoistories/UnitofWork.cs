using TradingJournal.Data;
using TradingJournal.Repoistories.Interfaces;

namespace TradingJournal.Repoistories
{
    public class UnitofWork:IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRegistrationRepoistories _userRegistrationRepoistories;
        private IJournalRepoistories _journalRepoistories;


        public UnitofWork(ApplicationDbContext context, IUserRegistrationRepoistories userRegistrationRepoistories, IJournalRepoistories journalRepoistories)
        {
            _context = context;
            _userRegistrationRepoistories = userRegistrationRepoistories;
            _journalRepoistories = journalRepoistories;
        }

          public IJournalRepoistories JournalRepoistories
        {
            get
            {
                return _journalRepoistories = _journalRepoistories ?? new JournalRepoistories(_context);
            }
        }

      
        public IUserRegistrationRepoistories UserRegistrationRepoistories
        {
            get
            {
                return _userRegistrationRepoistories ?? new UserRegistrationRepoistories(_context);
            }
        }

       

        public void Commit()
        {
            _context.SaveChanges();
        }

       
    }
}
