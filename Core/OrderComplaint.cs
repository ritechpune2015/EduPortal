using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("OrderComplaintTbl")]
    public class OrderComplaint
    {
        [Key]
        public Int64 OrderComplaintID { get; set; }
        public DateTime ComplaintDate { get; set; }
        [ForeignKey("Order")]
        public Int64 OrderID { get; set; }
        public string ComplaintTitle { get; set; }
        public string ComplaintDescription { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<OrderComplaintSolution> OrderComplaintSolutions { get; set; }
    }
}
