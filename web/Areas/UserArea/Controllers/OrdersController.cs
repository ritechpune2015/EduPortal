using Core;
using Microsoft.AspNetCore.Mvc;
using Repo;
using web.CustFilter;

namespace web.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [UserAuth]
    public class OrdersController : Controller
    {
        IOrderRepo orepo;
        public OrdersController(IOrderRepo orepo)
        {
            this.orepo = orepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Int64 id)
        {
            var rec = this.orepo.GetById(id);
            return View(rec);
        }
            
        [HttpGet]
        public IActionResult RaiseComplaint(Int64 id)
        {
            ViewBag.OrderID = id;
            return View();
        }


        [HttpPost]
        public IActionResult RaiseComplaint(OrderComplaint rec)
        {
            if (ModelState.IsValid)
            {
                var res = this.orepo.RaiseComplaint(rec);
                if (res.IsSuccess)
                {
                    return RedirectToAction("Index", "Complaints");
                }
                else
                {
                    ViewBag.Message = res.Message;
                }
            }
            return View(rec);
        }
    }
}
