using Core;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IUserRepo
    {
        LoginResultVM Login(LoginVM rec);
   
        RepoResultVM ChangePassword(ChangePasswordVM rec,Int64 id);
        RepoResultVM SignUp(User rec);

       // RepoResultVM EditProfile(CompanyProfileVM rec,Int64 id);
      //  CompanyProfileVM GetById(Int64 id);
    }
}
