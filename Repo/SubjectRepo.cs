using Core;
using Infra;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class SubjectRepo:GenRepo<Subject>,ISubjectRepo
    {
        CompanyContext cc;
        public SubjectRepo(CompanyContext cc):base(cc)
        {
            this.cc = cc;
        }

        public List<SubjectVM> GetSubjectByStreamId(long streamid)
        {
            //  return this.cc.Subject.Where(p => p.SubjectStreamID == streamid).ToList();
            var v = from t in this.cc.Subject
                    where t.SubjectStreamID==streamid
                    select new SubjectVM
                    {
                       SubjectID=t.SubjectID,
                       SubjectName=t.SubjectName
                    };

            return v.ToList();

        }
     }
}
