﻿using OneToOne.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne.Service.DTOs
{
    public class PersonDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required PassportDto Passport { get; set; }
    }
}
