using Microsoft.AspNetCore.Mvc;
using Repo;

namespace web.ViewComponents
{
    public class SolvedComplaintsVC:ViewComponent
    {
        IOrderRepo repo;
        public SolvedComplaintsVC(IOrderRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var v = this.repo.GetAllSolvedComplaints();
            return View(v.ToList());
        }
    }
}
