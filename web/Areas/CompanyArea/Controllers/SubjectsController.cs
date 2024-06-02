using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repo;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class SubjectsController : Controller
    {
        ISubjectRepo repo;
        ISubjectStreamRepo streamRepo;
        public SubjectsController(ISubjectRepo repo,ISubjectStreamRepo streamRepo    )
        {
            this.repo = repo;
            this.streamRepo = streamRepo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Streams = new SelectList(this.streamRepo.GetAll(), "SubjectStreamID", "StreamName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject rec)
        {
            ViewBag.Streams = new SelectList(this.streamRepo.GetAll(), "SubjectStreamID", "StreamName");
            if (ModelState.IsValid)
            {
                this.repo.Add(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.repo.GetById(id);
            ViewBag.Streams = new SelectList(this.streamRepo.GetAll(), "SubjectStreamID", "StreamName",rec.SubjectStreamID);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Subject rec)
        {
            ViewBag.Streams = new SelectList(this.streamRepo.GetAll(), "SubjectStreamID", "StreamName", rec.SubjectStreamID);

            if (ModelState.IsValid)
            {
                this.repo.Edit(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Delete(Int64 id)
        {
            this.repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
