using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class Evaluation
    {
        [Key]
        public int Id { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public int OperatorId { get; set; }




    }
}
