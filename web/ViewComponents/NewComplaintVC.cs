using Microsoft.AspNetCore.Mvc;
using Repo;

namespace web.ViewComponents
{
    public class NewComplaintVC:ViewComponent
    {
        IOrderRepo repo;
        public NewComplaintVC(IOrderRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var v = this.repo.GetAllNewComplaints();
            return View(v.ToList());
        }
    }
}
