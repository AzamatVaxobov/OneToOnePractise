using OneToOne.DataAccess.Entities;
using OneToOne.Repository.PersonRepository;
using OneToOne.Service.DTOs;

namespace OneToOne.Service.PersonService
{
    
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public long AddPerson(PersonCreateDto personCreateDto)
        {
            var person = new Person()
            {
                Name = personCreateDto.Name,
            };

            return _personRepository.InsertPerson(person);
        }

        public ICollection<PersonDto> GetAll()
        {
            var people = _personRepository.SelectAll();
            return people.Select(person => new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Passport = null,
            }).ToList();
        }

        public PersonDto GetPersonById(long personId)
        {
            var person = _personRepository.GetPersonById(personId);
            if (person == null) return null;
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Passport = null
            };

        }
        public PersonDto GetPersonByIdWithPassport(long personId)
        {
            var person = _personRepository.GetPersonByIdWithPassport(personId);
            if (person == null) return null; // Handle not found

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,

                // Map the Passport entity to PassportDto
                Passport = person.Passport != null ? new PassportDto
                {
                    Id = person.Passport.Id,
                    PassportNumber = person.Passport.PassportNumber,
                    PersonId = person.Passport.PersonId
                } : null // If person doesn't have a passport, return null
            };
        }




        public void RemovePerson(long personId)
        {
            _personRepository.DeletePerson(personId);
        }

        public void UpdatePerson(PersonDto personDto)
        {
            var person = new Person
            {
                Id = personDto.Id,
                Name = personDto.Name,
                // Add other properties if needed
            };

            _personRepository.UpdatePerson(person);
        }
    }
}
