using OneToOne.DataAccess.Entities;
using OneToOne.Service.DTOs;

namespace OneToOne.Service.PassportService
{
    public interface IPassportService
    {
        long AddPassport(PassportCreateDto passportCreateDto);
        ICollection<PassportDto> GetAllPassports();
        void RemovePassport(long passportId);
        PassportDto GetById(long passportId);
    }
}