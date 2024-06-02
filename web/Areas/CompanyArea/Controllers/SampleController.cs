using Microsoft.AspNetCore.Mvc;

namespace web.Areas.CompanyArea.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
