using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        public long Rut { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(90)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int AreaId { get; set; }
        public int RoleId { get; set; }
        public int EvaluationId { get; set; }
        public int AvailabilityId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("AvailabilityId")]
        public Availability Availability { get; set; }


        [ForeignKey("EvaluationId")]
        public Evaluation Evaluation{ get; set; }




    }
}
