using OneToOne.DataAccess;
using OneToOne.DataAccess.Entities;

namespace OneToOne.Repository.PassportRepository
{
    public class PassportRepository : IPassportRepository
    {
        private readonly MainContext _context;
        public PassportRepository(MainContext context)
        {
            _context = context;
        }

        public void DeletePassport(long passportId)
        {
            var passport = _context.Passports.FirstOrDefault(p => p.Id == passportId);
            if (passport == null) 
            {
                throw new Exception($"Id with {passportId} not found to delete ");
            }

            _context.Passports.Remove( passport );
            _context.SaveChanges();

        }

        public Passport GetById(long passportId)
        {
            var passport = _context.Passports.FirstOrDefault(p => p.Id == passportId);
            if (passport == null)
            {
                throw new Exception($"Id with {passportId} not found");
            }

            return passport;
        }

        public long InsertPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            _context.SaveChanges();

            return passport.Id;
        }

        public ICollection<Passport> SelectAll()
        {
            return _context.Passports.ToList();
        }
    }
}
