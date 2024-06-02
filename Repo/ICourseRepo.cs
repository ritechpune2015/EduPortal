using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ICourseRepo:IGenRepo<Course>
    {
        List<Course> GetCourseBySubjectId(Int64 subjectid);
    }
}
