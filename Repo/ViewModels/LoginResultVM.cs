using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repo.ViewModels
{
    public class LoginResultVM
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public Int64 LoggedInID { get; set; }
        public string LoggedInName { get; set; }

    }
}
