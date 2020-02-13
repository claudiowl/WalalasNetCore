using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Walalas.Api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string DirectionStart { get; set; }

        public string DirectionEnd { get; set; }

        public int Distance { get; set; }



 
    
        public int UserId { get; set; }
        public int OperatorId { get; set; }
        public int LockerId { get; set; }
        public int StatusOrderId { get; set; }


        [ForeignKey("UserId")]
        public  User User { get; set; }

        [ForeignKey("OperatorId")]
        public Operator Operator { get; set; }


        [ForeignKey("LockerId")]
        public Locker Locker { get; set; }


        [ForeignKey("StatusOrderId")]
        public StatusOrder StatusOrder { get; set; }






    }
}
