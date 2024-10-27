﻿using OneToOne.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne.Service.DTOs
{
    public class PassportDto
    {
        public long Id { get; set; }
        public required string PassportNumber { get; set; }
        public long PersonId { get; set; }
        
    }
}
