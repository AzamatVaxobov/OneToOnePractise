using Microsoft.AspNetCore.Mvc;
using OneToOne.Service.DTOs;
using OneToOne.Service.PassportService;

namespace OneToOne.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {
        private readonly IPassportService _passportService;
        public PassportController(IPassportService passportService)
        {
            _passportService = passportService;
        }
        [HttpPost]
        public long PostPassport(PassportCreateDto passportCreateDto)
        {
            var passportId = _passportService.AddPassport(passportCreateDto);
            return passportId;
        }
        [HttpDelete("{passportId}")]
        public void DeletePassport(long passportId)
        {
            _passportService.RemovePassport(passportId);
        }
        [HttpGet]
        public ICollection<PassportDto> GetAllPassport()
        {
            var passports = _passportService.GetAllPassports();
            return passports;
        }
        [HttpGet("{passportId}")]
        public PassportDto GetPassportById(long passportId)
        {
            var passport = _passportService.GetById(passportId);
            return passport;
        }
    }
}
