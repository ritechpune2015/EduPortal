using Core;
using Microsoft.AspNetCore.Mvc;
using Repo;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class SubjectStreamsController : Controller
    {
        ISubjectStreamRepo repo;
        public SubjectStreamsController(ISubjectStreamRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubjectStream rec)
        {
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
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(SubjectStream rec)
        {
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
