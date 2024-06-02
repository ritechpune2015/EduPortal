using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.ViewModels;
using web.CustFilter;

namespace web.Areas.UserArea.Controllers
{

    [Area("UserArea")]
    [UserAuth]
    public class UserHomeController : Controller
    {
        IUserRepo repo;
        public UserHomeController(IUserRepo repo)
        {
            this.repo = repo;
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
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
                var res = this.repo.ChangePassword(rec, cid);
                ViewBag.Message = res.Message;
            }
            return View(rec);
        }

    }
}
