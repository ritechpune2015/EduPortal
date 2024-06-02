using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CartTbl")]
    public class Cart
    {
        [Key]
        public Int64 CartID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 CourseID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
