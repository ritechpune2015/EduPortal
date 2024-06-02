using Core;
using Infra;
using Repo.Emums;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class OrderRepo : GenRepo<Order>, IOrderRepo
    {
        CompanyContext cc;
        public OrderRepo(CompanyContext cc) : base(cc)
        {
            this.cc = cc;
        }

        public List<Order> GetAllByUserID(long userid)
        {
            return this.cc.Orders.Where(p => p.UserID == userid).ToList();
        }

        public List<OrderComplaint> GetAllComplaints()
        {
            return this.cc.OrderComplaints.ToList();
        }

        public List<OrderComplaint> GetAllSolvedComplaints()
        {
            var v = from t in this.cc.OrderComplaints
                    join t1 in this.cc.OrderComplaintSolution
                    on t.OrderComplaintID equals t1.OrderComplaintID
                    select t;
            return v.ToList();
        }


        public List<OrderComplaint> GetAllNewComplaints()
        {
            var v = from t in this.cc.OrderComplaints
                    where !(from t1 in this.cc.OrderComplaintSolution
                           select t1.OrderComplaintID)
                            .Contains(t.OrderComplaintID)
                    select t;

            return v.ToList();
        }

        public List<OrderDet> GetOrderDetByUserID(long userid)
        {
            var v = from t in this.cc.Orders
                    join t1 in this.cc.OrderDets
                    on t.OrderID equals t1.OrderID
                    where t.UserID == userid
                    select t1;

            return v.ToList();
        }

        public RepoResultVM RaiseComplaint(OrderComplaint rec)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                rec.ComplaintDate = DateTime.Now;
                this.cc.OrderComplaints.Add(rec);
                this.cc.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Complaint Raised!";
                return res;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.ToString();
            }
            return res;
        }

        public RepoResultVM AddComplaintSolution(OrderComplaintSolution rec)
        {

            RepoResultVM res = new RepoResultVM();
            try
            {
                rec.SolutionDate = DateTime.Now;
                this.cc.OrderComplaintSolution.Add(rec);
                this.cc.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Solution Added!";
                return res;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.ToString();
            }

            return res;
        }

        public OrderComplaintSolution GetSolutionByComplaintID(long ComplaintID)
        {
            return this.cc.OrderComplaintSolution.FirstOrDefault(p => p.OrderComplaintID == ComplaintID);
        }
    }
}
