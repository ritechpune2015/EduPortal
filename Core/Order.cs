using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("OrderTbl")]
    public class Order
    {
        [Key]
        public Int64 OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 UserID { get; set; }
        public bool IsPaid { get; set; }
        public virtual User User { get; set; }
        public virtual List<OrderDet> OrderDets { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
        public virtual List<OrderComplaint> OrderComplaints { get; set; }
        public Order()
        {
            OrderDets = new List<OrderDet>();
            OrderPayments = new List<OrderPayment>();
        }
    }
}
