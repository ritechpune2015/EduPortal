using Microsoft.AspNetCore.Mvc;
using Repo;

namespace web.ViewComponents
{
    public class CartCountVM:ViewComponent
    {
        ICartRepo repo;
        public CartCountVM(ICartRepo repo)
        {
            this.repo = repo;
        }   

        public IViewComponentResult Invoke(Int64 userid)
        {
            var cnt = this.repo.GetCartCount(userid);
            return View(cnt);
        }

    }
}
