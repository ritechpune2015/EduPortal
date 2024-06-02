using Core;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ICartRepo:IGenRepo<Cart>
    {

        RepoResultVM AddToCart(Int64 courseid, Int64 userid);
        int GetCartCount(Int64 userid);
        List<Cart> GetAllByUserID(Int64 userid);

        RepoResultVM PlaceOrder(Int64 userid, int pmode);
    }
}
