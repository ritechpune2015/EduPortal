using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    [Table("TrainingCompanyTbl")]
    public class TrainingCompany
    {
        [Key]
        public Int64 TrainingCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string WebsiteUrl { get; set; }
        public string Password { get; set; }
        public virtual List<TrainingCompany> TrainingCompanies { get; set; }
    }
}
