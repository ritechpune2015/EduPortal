using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("OrderPaymentTbl")]
    public class OrderPayment
    {
        [Key]
        public Int64 OrderPaymentID { get; set; }
        public Int64 OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMode { get; set; }

        public virtual Order Order { get; set; }

    }
}
