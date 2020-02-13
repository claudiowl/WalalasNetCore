﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class StatusOrder
    {

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
