using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }


    }
}
