using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repo;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        ICourseRepo repo;
        ISubjectStreamRepo streamrepo;
        ISubjectRepo subrepo;
        public HomeController(ICourseRepo repo, ISubjectStreamRepo stremrepo,ISubjectRepo srepo)
        {
            this.repo = repo;
            this.streamrepo = stremrepo;
            this.subrepo = srepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCourses(Int64 id=0)
        {
            ViewBag.Streams = new SelectList(this.streamrepo.GetAll(),"SubjectStreamID","StreamName");
            if (id == 0)
                return View(this.repo.GetAll());
            else
            {
                var v = this.repo.GetCourseBySubjectId(id);
                return View(v);
            }     
        }

        public IActionResult GetCourseDetails(Int64 id)
        {

            var rec = this.repo.GetById(id);
            return View(rec);
        }

        public IActionResult GetSubjetsJson(Int64 id)
        {
            var rec = this.subrepo.GetSubjectByStreamId(id);
            return Json(rec.ToList());
        }
    }
}
