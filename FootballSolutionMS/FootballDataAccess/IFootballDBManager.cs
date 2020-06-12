using FootballDataAccess.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataAccess
{
    public interface IFootballDBManager
    {
        Task<List<FootballPersonTable>> GetAllPersonsAsync();
        Task<int> AddNewPersonAsync(FootballPersonTable footballPerson);
        Task DeleteAsync(int id);
    }
}
