using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.ViewModels;

namespace web.Controllers
{
    public class ManageTrainingCompaniesController : Controller
    {
        ITrainingCompany repo;
        public ManageTrainingCompaniesController(ITrainingCompany repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginVM rec)
        {
            if (ModelState.IsValid)
            {
               var res=this.repo.Login(rec);
                if (res.IsSuccess)
                {
                    //divert the user to area
                    HttpContext.Session.SetString("CompanyID", res.LoggedInID.ToString());
                    HttpContext.Session.SetString("CompanyName", res.LoggedInName);
                    return RedirectToAction("Index", "TrainingCompanyHome", new { area = "CompanyArea" });
                }
                else {
                    ModelState.AddModelError("", res.ErrorMessage);
                    return View(rec);
                }
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
