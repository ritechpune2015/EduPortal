using Core;
using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.ViewModels;

namespace web.Controllers
{
    public class ManageUsersController : Controller
    {
        IUserRepo repo;
        public ManageUsersController(IUserRepo repo)
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
                    HttpContext.Session.SetString("UserID", res.LoggedInID.ToString());
                    HttpContext.Session.SetString("UserName", res.LoggedInName);
                    // return RedirectToAction("Index", "UserHome", new { area = "UserArea" });
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", res.ErrorMessage);
                    return View(rec);
                }
            }
            return View(rec);
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User rec)
        {
            if (ModelState.IsValid)
            {
                var res=this.repo.SignUp(rec);
                if (res.IsSuccess)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", res.Message);
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
