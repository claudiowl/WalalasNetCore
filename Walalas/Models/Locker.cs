using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class Locker

    {
        [Key]
        public int IdNumber { get; set; }
        public int Avaibility { get; set; }
        public int Location { get; set; }

        
    }   
}       
