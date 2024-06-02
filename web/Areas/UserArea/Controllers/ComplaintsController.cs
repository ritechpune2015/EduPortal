using Microsoft.AspNetCore.Mvc;
using web.CustFilter;

namespace web.Areas.UserArea.Controllers
{

    [Area("UserArea")]
    [UserAuth]
    public class ComplaintsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
