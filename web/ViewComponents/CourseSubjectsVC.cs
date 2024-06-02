using Microsoft.AspNetCore.Mvc;
using Repo;

namespace web.ViewComponents
{
    public class CourseSubjectsVC:ViewComponent
    {
        ISubjectStreamRepo isubrepo;
        public CourseSubjectsVC(ISubjectStreamRepo isubrepo)
        {
            this.isubrepo = isubrepo;
        }

        public IViewComponentResult Invoke()
        {
            var rec = this.isubrepo.GetAll();
            return View(rec); //default.cshtml
        }
    }

}
