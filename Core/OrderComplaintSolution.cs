using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("OrderComplaintSolutionTbl")]
    public class OrderComplaintSolution
    {
        [Key]
        public Int64 OrderComplaintSolutionID { get; set; }
        [ForeignKey("OrderComplaint")]
        public Int64 OrderComplaintID { get; set; }
        public DateTime SolutionDate { get; set; }
        public string SolutionTitle { get; set; }
        public string SolutionDesc { get; set; }
        public virtual OrderComplaint OrderComplaint { get; set; }

    }
}
