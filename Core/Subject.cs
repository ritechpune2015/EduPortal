using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("SubjecTbl")]
    public class Subject
    {
        [Key]
        public Int64 SubjectID { get; set; }
        [Required(ErrorMessage="Subject Name Required")]
        public string SubjectName { get; set; }
        public Int64 SubjectStreamID { get; set; }
        public virtual SubjectStream Stream { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
