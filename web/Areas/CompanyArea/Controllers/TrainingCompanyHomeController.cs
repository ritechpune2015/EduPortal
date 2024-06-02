using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.ViewModels;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class TrainingCompanyHomeController : Controller
    {
        ITrainingCompany repo;
        public TrainingCompanyHomeController(ITrainingCompany trepo)
        {
            this.repo = trepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                var res=this.repo.ChangePassword(rec,cid);
                ViewBag.Message = res.Message;
            }
            return View(rec);
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var rec = this.repo.GetById(cid);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditProfile(CompanyProfileVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                var res = this.repo.EditProfile(rec, cid);
                ViewBag.Message = res.Message;
            }
            return View(rec);
        }

    }
}
