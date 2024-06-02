using Core;
using Infra;
using Repo.Emums;
using Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class CartRepo:GenRepo<Cart>,ICartRepo
    {
        CompanyContext cc;
        public CartRepo(CompanyContext cc):base(cc)
        {
            this.cc = cc;
        }

        public RepoResultVM AddToCart(long courseid, long userid)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                var oldcart = this.cc.Carts.SingleOrDefault(p => p.CourseID == courseid && p.UserID == userid);
                if (oldcart != null)
                {
                    oldcart.Qty++;
                    this.cc.SaveChanges();
                }
                else
                {
                    var courserec = this.cc.Courses.Find(courseid);
                    Cart newcart = new Cart();
                    newcart.CourseID = courseid;
                    newcart.Price = courserec.Price;
                    newcart.Qty = 1;
                    newcart.UserID = userid;
                    this.cc.Carts.Add(newcart);
                    this.cc.SaveChanges();
                }
                res.IsSuccess = true;
                res.Message = "Product Added To Cart!";
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public List<Cart> GetAllByUserID(long userid)
        {
            return this.cc.Carts.Where(p => p.UserID == userid).ToList();
        }

        public int GetCartCount(long userid)
        {
            return  this.cc.Carts.Where(p => p.UserID == userid).Count();
        }

        public RepoResultVM PlaceOrder(long userid, int pmode)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                //find records from cart        
                var carts = this.cc.Carts.Where(p => p.UserID == userid);

                //order 
                Order rec = new Order();
                rec.OrderDate = DateTime.Now;
                if (pmode == (int)PaymentModeEnum.CashOnDelivery)
                    rec.IsPaid = false;
                else
                    rec.IsPaid = true;
                rec.UserID = userid;

                foreach (var temp in carts)
                {
                    OrderDet ordet = new OrderDet();
                    ordet.CourseID = temp.CourseID;
                    ordet.Qty = temp.Qty;
                    ordet.Price = temp.Price;
                    rec.OrderDets.Add(ordet);
                }

                if (pmode != (int)PaymentModeEnum.CashOnDelivery)
                {
                    OrderPayment ordp = new OrderPayment();
                    ordp.PaymentDate = DateTime.Now;
                    ordp.Amount = carts.Sum(p => p.Price * p.Qty);
                    ordp.PaymentMode = pmode;
                    rec.OrderPayments.Add(ordp);
                }

                this.cc.Orders.Add(rec);
                this.cc.SaveChanges();

                //empty cart
                var oldcar = this.cc.Carts.Where(p => p.UserID == userid);
                foreach (var temp in oldcar)
                {
                    this.cc.Carts.Remove(temp);
                }
                this.cc.SaveChanges();
                res.IsSuccess = true;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message.ToString();
            }
            return res;
        }
    }
}
