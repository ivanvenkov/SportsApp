using Domain.Adaptors;
using Domain.Facotry;
using Domain.Models;
using FootballDataAccess;
using FootballDataAccess.Database;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.Application
{
    public class PersonManager : IPersonManager
    {
        private readonly IFootballDBManager footballDBManager;
        private readonly Adaptor adaptor;

        public PersonManager(IFactory factory)
        {
            this.footballDBManager = factory.GetFootballDBManager();
            this.adaptor = factory.GetAdaptor();
        }
        public async Task<List<PersonVM>> GetPersonsAsync()
        {
            var footballPersons = this.adaptor.GetPersons(await this.footballDBManager.GetAllPersonsAsync());
            return footballPersons;
        }

        public async Task<int> AddNewPersonAsync(PersonVM person)
        {
            var footbalPersonTble = new FootballPersonTable { Name = person.PersonName };
            var id = await this.footballDBManager.AddNewPersonAsync(footbalPersonTble);
            return id;
        }

        public async Task DeleteAsync(int id)
        {
            await this.footballDBManager.DeleteAsync(id);
        }
    }
}
