namespace TradingJournal.Repoistories.Interfaces
{
    public interface IUnitofWork
    {
        IUserRegistrationRepoistories UserRegistrationRepoistories { get;  }
        IJournalRepoistories JournalRepoistories { get;  }

        void Commit();
        void Update();
    }
}
