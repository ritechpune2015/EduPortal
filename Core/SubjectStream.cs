using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("SubjectStreamTbl")]
    public class SubjectStream
    {
        [Key]
        public Int64 SubjectStreamID { get; set; }
        [Required(ErrorMessage="Stream Name Required")]
        public string StreamName { get; set; }
        public virtual List<Subject> Subjects { get; set; }
    }
}