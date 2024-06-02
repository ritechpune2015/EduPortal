using Core;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class CourseRepo:GenRepo<Course>,ICourseRepo
    {
        CompanyContext cc;
        public CourseRepo(CompanyContext cc):base(cc)
        {
            this.cc = cc;
        }

        public List<Course> GetCourseBySubjectId(long subjectid)
        {
            return this.cc.Courses.Where(p => p.SubjectID == subjectid).ToList();
        }
    }
}
