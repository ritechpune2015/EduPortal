using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repo;
using web.CustFilter;

namespace web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class CoursesController : Controller
    {
        ICourseRepo repo;
        ISubjectRepo subRepo;
        IWebHostEnvironment env;
        public CoursesController(ICourseRepo repo,ISubjectRepo subRepo,IWebHostEnvironment env)
        {
            this.repo = repo;
            this.subRepo = subRepo;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Subjects = new SelectList(this.subRepo.GetAll(), "SubjectID", "SubjectName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course rec)
        {
            ViewBag.Subjects = new SelectList(this.subRepo.GetAll(), "SubjectID", "SubjectName");
            if (ModelState.IsValid)
            {
                if (rec.ActualFile!=null)
                {
                    if (rec.ActualFile.Length > 0)
                    {
                        string filename = rec.ActualFile.FileName;
                        string folderpath =Path.Combine(this.env.WebRootPath,"courseimages");
                        string uploadpath = Path.Combine(folderpath, filename);
                        FileStream fs = new FileStream(uploadpath, FileMode.Create);
                        rec.ActualFile.CopyTo(fs);
                        string logicalpath = Path.Combine("\\courseimages", filename);
                        rec.ImageFilePath = logicalpath;
                    }
                }
                Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                rec.TrainingCompanyID = companyid;
                this.repo.Add(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.repo.GetById(id);
            ViewBag.Subjects = new SelectList(this.subRepo.GetAll(), "SubjectID", "SubjectName",rec.SubjectID);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Course rec)
        {
            ViewBag.Subjects = new SelectList(this.subRepo.GetAll(), "SubjectID", "SubjectName", rec.SubjectID);
            if (ModelState.IsValid)
            {
                if (rec.ActualFile != null)
                {
                    if (rec.ActualFile.Length > 0)
                    {
                        string filename = rec.ActualFile.FileName;
                        string folderpath = Path.Combine(this.env.WebRootPath, "courseimages");
                        string uploadpath = Path.Combine(folderpath, filename);
                        FileStream fs = new FileStream(uploadpath, FileMode.Create);
                        rec.ActualFile.CopyTo(fs);
                        string logicalpath = Path.Combine("\\courseimages", filename);
                        rec.ImageFilePath = logicalpath;
                    }
                }

                Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                rec.TrainingCompanyID = companyid;
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

        [HttpGet]
        public IActionResult Details(Int64 id)
        {
            var rec = this.repo.GetById(id);
            return View(rec);
        }
    }
}
