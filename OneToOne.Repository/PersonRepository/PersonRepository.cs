using Microsoft.EntityFrameworkCore;
using OneToOne.DataAccess;
using OneToOne.DataAccess.Entities;

namespace OneToOne.Repository.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainContext _context;
        public PersonRepository(MainContext context)
        {
            _context = context;
        }

        public void DeletePerson(long personId)
        {
            var person = _context.People.FirstOrDefault(st => st.Id == personId);
            if (person != null) 
            {
                throw new Exception($"Person with id {{personId}} not found to delete");
            }

            _context.People.Remove(person);
            _context.SaveChanges();
        }

        public Person GetPersonById(long personId)
        {
            var person = _context.People.FirstOrDefault(p => p.Id == personId);
            if (person == null)
            { 
                throw new Exception($" Person with {personId} not found ");
            }

            return person;
        }

        public Person GetPersonByIdWithPassport(long personId)
        {
            var person = _context.People
                .Include(p => p.Passport) //Eager loading
                .FirstOrDefault(p => p.Id == personId);
            if (person == null)
            {
                throw new Exception($"Person with id {personId} not found");
            }

            return person;
        }

        public long InsertPerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public ICollection<Person> SelectAll()
        {
            return _context.People.ToList();
        }

        public void UpdatePerson(Person person)
        {
            var existingPerson = _context.People.Include(p => p.Passport).FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson == null)
            {
                throw new Exception($"Person with id {person.Id} not found to update");
            }   
            
            existingPerson.Name = person.Name;
        }
    }
}
