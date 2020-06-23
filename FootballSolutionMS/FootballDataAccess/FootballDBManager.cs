using FootballDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataAccess
{
    public class FootballDBManager : IFootballDBManager
    {
        private readonly FootballDbContext footballDbContext;
        public FootballDBManager(FootballDbContext footballDbContext)
        {
            this.footballDbContext = footballDbContext;
        }

        public async Task<List<FootballPersonTable>> GetAllPersonsAsync()
        {
            return await footballDbContext.FootballPersons.ToListAsync();
        }

        public async Task<int> AddNewPersonAsync(FootballPersonTable footballPerson)
        {
            int nextId = await this.GetNextValueAsync();
            footballPerson.Id = nextId;
            await this.footballDbContext.FootballPersons.AddAsync(footballPerson);
            await footballDbContext.SaveChangesAsync();
            return footballPerson.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var footballPerson = await this.footballDbContext.FootballPersons.SingleOrDefaultAsync(f => f.Id == id);
            this.footballDbContext.FootballPersons.Remove(footballPerson);
            await this.footballDbContext.SaveChangesAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = footballDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select FOOTBALL_PERSON.NEXTVAL from dual";
                footballDbContext.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }
    }
}
