using Core;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IOrderRepo:IGenRepo<Order>
    {
        List<Order> GetAllByUserID(Int64 userid);
        List<OrderDet> GetOrderDetByUserID(Int64 userid);
        RepoResultVM RaiseComplaint(OrderComplaint rec);
        RepoResultVM AddComplaintSolution(OrderComplaintSolution rec);
        List<OrderComplaint> GetAllComplaints();
        List<OrderComplaint> GetAllSolvedComplaints();
        List<OrderComplaint> GetAllNewComplaints();
        OrderComplaintSolution GetSolutionByComplaintID(Int64 ComplaintID);

    }
}
