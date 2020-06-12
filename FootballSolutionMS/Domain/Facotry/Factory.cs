using Domain.Adaptors;
using FootballDataAccess;
using FootballDataAccess.Database;

namespace Domain.Facotry
{
    public class Factory : IFactory
    {
        private readonly FootballDbContext footballDbContext;

        public Factory(FootballDbContext footballDbContext)
        {
            this.footballDbContext = footballDbContext;
        }       

        public IFootballDBManager GetFootballDBManager()
        {
            IFootballDBManager dBManager = new FootballDBManager(footballDbContext);
            return dBManager;
        }

        public Adaptor GetAdaptor()
        {
            return new Adaptor();
        }
    }
}
