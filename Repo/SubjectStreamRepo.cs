using Core;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class SubjectStreamRepo:GenRepo<SubjectStream>,ISubjectStreamRepo
    {
        CompanyContext cc;
        public SubjectStreamRepo(CompanyContext cc):base(cc)
        {
            this.cc = cc;
        }
    }
}
