using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public interface IPersonManager
    {
        Task<List<PersonVM>> GetPersonsAsync();
        Task<int> AddNewPersonAsync(PersonVM person);
        Task DeleteAsync(int id);
    }
}
