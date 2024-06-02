using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.Emums;
using web.CustFilter;

namespace web.Controllers
{
    [UserAuth]
    public class CartController : Controller
    {
        ICartRepo repo;
        public CartController(ICartRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult AddToCart(Int64 courseid)
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.AddToCart(courseid, userid);
            TempData["Message"] = res.Message;
           return RedirectToAction("GetCourses", "Home");
            
        }

        public IActionResult GetCart()
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var rec = this.repo.GetAllByUserID(userid);
            return View(rec.ToList());
        }


        public IActionResult DeleteCart(Int64 CartID)
        {
            this.repo.Delete(CartID);
            return RedirectToAction("GetCart");
        }

        public IActionResult CheckOut(int PaymentMode)
        {
            if (PaymentMode == (int)PaymentModeEnum.CashOnDelivery)
            {
                return RedirectToAction("PlaceOrder", new { pmode = PaymentMode });
            }
            else
            {
                return RedirectToAction("PaymentGateway", new { pmode = PaymentMode });
            }
        }

        public IActionResult PlaceOrder(int pmode)
        {
            //find userid
            Int64 userid =Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.PlaceOrder(userid, pmode);
            if (res.IsSuccess)
            {
                return View();
            }
            ViewBag.Message = res.Message;
            return RedirectToAction("GetCart");
        }

        [HttpGet]
        public IActionResult PaymentGateway(int pmode)
        {
            //payment gateway code. 
            ViewBag.PaymentMode = pmode;
                   return View();
        }


        [HttpPost]
        [ActionName("PaymentGateway")]
        public IActionResult ProcessPaymentGateway(int pmode)
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var res = this.repo.PlaceOrder(userid, pmode);
            if (res.IsSuccess)
            {
                return View("PlaceOrder");
            }
            ViewBag.Message = res.Message;
            return RedirectToAction("GetCart");
        }
    }
}
