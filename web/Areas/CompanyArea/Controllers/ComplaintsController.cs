using Core;
using Microsoft.AspNetCore.Mvc;
using Repo;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ComplaintsController : Controller
    {
        IOrderRepo repo;
        public ComplaintsController(IOrderRepo trepo)
        {
            this.repo = trepo; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TakeAction(Int64 id)
        {
            ViewBag.ComplaintID = id;
            return View();
        }


        [HttpPost]
        public IActionResult TakeAction(OrderComplaintSolution rec)
        {
            if (ModelState.IsValid)
            {
                var res = this.repo.AddComplaintSolution(rec);
                if (res.IsSuccess)
                {
                    TempData["Message"] = res.Message;
                    return RedirectToAction("Index");
                }
                ViewBag.Message = res.Message;
            }
            return View(rec);
        }


        [HttpGet]
        public IActionResult ViewSolution(Int64 id)
        {
            var rec = this.repo.GetSolutionByComplaintID(id);
            return View(rec);
        }

    }

}
