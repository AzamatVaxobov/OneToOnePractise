using OneToOne.DataAccess.Entities;

namespace OneToOne.Repository.PersonRepository
{
    public interface IPersonRepository
    {
        long InsertPerson(Person person);
        ICollection<Person> SelectAll();
        void UpdatePerson(Person person);
        void DeletePerson(long personId);
        Person GetPersonById(long personId);
        Person GetPersonByIdWithPassport(long personId);

    }
}