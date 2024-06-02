using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CourseTbl")]
    public class Course
    {
        [Key]
        public Int64 CourseID { get; set; }
        public string CourseName { get; set; }
        public Int64 SubjectID { get; set; }
        public string CourseDescription { get; set; }
        public int DurationInHours { get; set; }
        public string Prerequisite { get; set; }
        public decimal Price { get; set; }
        public string ImageFilePath { get; set; }
        [NotMapped]
        public IFormFile ActualFile { set; get; }
        public  virtual Subject Subject { get; set; }
        public Int64 TrainingCompanyID { get; set; }
        public virtual List<OrderDet> OrderDets { get; set; }
        public virtual TrainingCompany TrainingCompany { get; set; }
        public virtual List<Cart> Carts { get; set; }
    }
}
