using OneToOne.DataAccess.Entities;
using OneToOne.Repository.PassportRepository;
using OneToOne.Service.DTOs;

namespace OneToOne.Service.PassportService
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository _passportRepository;
        public PassportService(IPassportRepository passportRepository)
        {
            _passportRepository = passportRepository;
        }
        public long AddPassport(PassportCreateDto passportCreateDto)
        {
            var passport = new Passport()
            {
                PassportNumber = passportCreateDto.PassportNumber,
                PersonId = passportCreateDto.PersonId,
            };

            return _passportRepository.InsertPassport(passport);
        }

        public ICollection<PassportDto> GetAllPassports()
        {
            var passports = _passportRepository.SelectAll();
            var passportDtos = new List<PassportDto>();

            foreach (var passport in passports)
            {
                passportDtos.Add(new PassportDto
                {
                    Id = passport.Id,
                    PassportNumber= passport.PassportNumber,
                    PersonId = passport.PersonId // Include the foreign key if needed
                });
            }

            return passportDtos;
        }

        public PassportDto GetById(long passportId)
        {
            var passport = _passportRepository.GetById(passportId);
            if (passport == null) return null; // Handle not found

            return new PassportDto
            {
                Id = passport.Id,
                PassportNumber=passport.PassportNumber,
                PersonId = passport.PersonId // Include the foreign key if needed
            };
        }

        public void RemovePassport(long passportId)
        {
            _passportRepository.DeletePassport(passportId);
        }
    }
}
