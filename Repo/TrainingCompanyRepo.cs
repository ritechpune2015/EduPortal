using Core;
using Infra;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class TrainingCompanyRepo : ITrainingCompany
    {
        CompanyContext cc;
        public TrainingCompanyRepo(CompanyContext cc)
        {
            this.cc = cc;
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec,Int64 id)
        {
            RepoResultVM res = new RepoResultVM();
            //find old record
            var oldrec = this.cc.TrainingCompanies.Find(id);
            if (oldrec.Password == rec.OldPassword)
            {
                oldrec.Password = rec.NewPassword;
                this.cc.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Password Changed Successfully!";
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "Invalid Old Password!";
            }

            return res;
        }

        public RepoResultVM EditProfile(CompanyProfileVM rec, long id)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                var oldrec = this.cc.TrainingCompanies.Find(id);
                oldrec.CompanyName= rec.CompanyName;
                oldrec.Address = rec.Address;
                oldrec.EmailID = rec.EmailID;
                oldrec.MobileNo = rec.MobileNo;
                oldrec.WebsiteUrl = rec.WebsiteUrl;
                this.cc.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Profile Updated!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message.ToString();
            }

            return res;
        }

        public CompanyProfileVM GetById(long id)
        {
            var rec = (from t in this.cc.TrainingCompanies
                      where t.TrainingCompanyID == id
                      select new CompanyProfileVM
                      {
                          CompanyName = t.CompanyName,
                          Address = t.Address,
                          EmailID = t.EmailID,
                          MobileNo = t.MobileNo,
                          WebsiteUrl = t.WebsiteUrl
                      }).FirstOrDefault();
            return rec;
        }

        public LoginResultVM Login(LoginVM rec)
        {
            LoginResultVM res = new LoginResultVM();
            var urec = this.cc.TrainingCompanies.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
            if (urec != null)
            {
                res.IsSuccess = true;
                res.LoggedInID = urec.TrainingCompanyID;
                res.LoggedInName = urec.CompanyName;
            }
            else
            {
                res.IsSuccess = false;
                res.ErrorMessage="Invalid Email ID or Password!";
            }
            return res;
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
