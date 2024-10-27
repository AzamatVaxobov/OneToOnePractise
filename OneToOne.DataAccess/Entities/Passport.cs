using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne.DataAccess.Entities
{
    public class Passport
    {
        public long Id { get; set; }
        public string PassportNumber { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
