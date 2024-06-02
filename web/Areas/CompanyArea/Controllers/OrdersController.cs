using Microsoft.AspNetCore.Mvc;
using Repo;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class OrdersController : Controller
    {
        IOrderRepo orepo;
        public OrdersController(IOrderRepo orepo)
        {
            this.orepo = orepo;
        }

        public IActionResult Index()
        {
            return View(this.orepo.GetAll());
        }

        [HttpGet]
        public IActionResult Details(Int64 id)
        {
            var rec = this.orepo.GetById(id);
            return View(rec);
        }
    }
}
