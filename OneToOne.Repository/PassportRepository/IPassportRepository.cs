using OneToOne.DataAccess.Entities;

namespace OneToOne.Repository.PassportRepository
{
    public interface IPassportRepository
    {
        long InsertPassport(Passport passport);
        ICollection<Passport> SelectAll();
        void DeletePassport(long passportId);
        Passport GetById (long passportId);
    }
}