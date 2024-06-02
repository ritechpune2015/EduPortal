using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ViewModels
{
    public class CompanyProfileVM
    {
        [Required(ErrorMessage="Company Name Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage="Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email IDRequired")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Mobile No Required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Website Url Required")]
        public string WebsiteUrl{ get; set; }
    }
}
