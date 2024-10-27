using OneToOne.DataAccess.Entities;
using OneToOne.Service.DTOs;

namespace OneToOne.Service.PersonService
{
    public interface IPersonService
    {
        long AddPerson(PersonCreateDto personCreateDto);
        ICollection<PersonDto> GetAll();
        void UpdatePerson(PersonDto personDto);
        void RemovePerson(long personId);
        PersonDto GetPersonById(long personId);
        PersonDto GetPersonByIdWithPassport(long personId);
    }
}