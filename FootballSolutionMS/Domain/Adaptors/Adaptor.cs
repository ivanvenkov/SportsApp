using Domain.Models;
using FootballDataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Adaptors
{
    public class Adaptor
    {
        public List<PersonVM> GetPersons(List<FootballPersonTable> list)
        {
            return list.Select(x => new PersonVM
            {
                PersonName = x.Name,
                SportType = 'F',
                SportTypeDescription = "Football"
            }).ToList();
        }

        public List<KpPersonModel> Transform(List<PersonVM> list)
        {
            return list.Select(x => new KpPersonModel
            {
                PersonName = x.PersonName,
                SportType = x.SportType,
                SportTypeDescription = x.SportTypeDescription
            }).ToList();
        }

        public PersonVM Transform(KpPersonModel person)
        {
            return new PersonVM
            {
                PersonName = person.PersonName,
                SportType = person.SportType,
                SportTypeDescription = person.SportTypeDescription
            };
        }
    }
}
