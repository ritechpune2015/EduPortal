using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    [Table("OrderDetTbl")]
    public class OrderDet
    {
        [Key]
        public Int64 OrderDetID { get; set; }
        public Int64 OrderID { get; set; }
        public Int64 CourseID { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public virtual Order Order { get; set; }
        public virtual Course Course { get; set; }
    }
}
