﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
