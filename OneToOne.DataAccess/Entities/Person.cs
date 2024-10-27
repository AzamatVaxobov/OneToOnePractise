namespace OneToOne.DataAccess.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Passport Passport { get; set; }
    }
}
