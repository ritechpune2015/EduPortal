using Microsoft.AspNetCore.Mvc;
using Repo;

namespace web.ViewComponents
{
    public class DashboardCourseVC:ViewComponent
    {
        IOrderRepo orepo;
        public DashboardCourseVC(IOrderRepo orderRepo)
        {
            this.orepo = orderRepo;
        }

        public IViewComponentResult Invoke(Int64 userid)
        {
            var res = this.orepo.GetOrderDetByUserID(userid);
            return View(res);        
        }
    }
}
