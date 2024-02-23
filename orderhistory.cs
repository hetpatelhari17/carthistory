using ECommerceShoppingCartAppASPNET7.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShoppingCartAppASPNET7.Controllers
{
    public class orderhistory : Controller
    {
        private readonly object _userManager;
        private string? orderlist;

        public OrderDetailsVM OrderDetailsVm { get; private set; }
        public object OrderDetailsVM { get; private set; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orderhistory(string? status)
        {
            var userId = _userManager.GetUserId(User);
            List<UserOrderHeader> orderLists = new List<UserOrderHeader>();
            if (status != null && status != "All")
            {
                if (User.IsInRole("Admin"))
                {
                    orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status).ToList();
                }
                else
                {
                    orderLists = _db.orderHeaders.Where(u => u.OrderStust == status && u.UserId == userId).ToList();
                }

            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    orderLists = _db.orderHeaders.ToList();
                }
                else
                {
                    orderLists = _db.orderHeaders.Where(u => u.UserId == userId).ToList();
                }
            }



            return View(orderlist);
        }

        //public IActionResult Orderhistory(string status)
        //{
        //    var userId = _userManager.GetUserId(User);
        //    List<UserOrderHeader> orderLists = new List<UserOrderHeader>();

        //    if (status != null && status != "All")
        //    {
        //        if (User.IsInRole("Admin"))
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status).ToList();
        //        }
        //        else
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status && u.UserId == userId).ToList();
        //        }
        //    }
        //    else
        //    {
        //        if (User.IsInRole("Admin"))
        //        {
        //            orderLists = _db.orderHeaders.ToList();
        //        }
        //        else
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.UserId == userId).ToList();
        //        }
        //    }

        //    return View(orderLists); // Corrected variable name to orderLists
        //}


        //public IActionResult OrderDetails(int orderId)
        //{
        //    OrderDetailsVm = new OrderDetailsVM();
        //    OrderDetailsVM.OrderHeader = _db.orderHeaders.FirstOrDefault(u => u.Id == orderId);
        //    OrderDetailsVM.userProductList = _db.orderDetails.Include(u => u.OrderHeaderId == orderId).ToList();
        //    return View(OrderDetailsVm);


        //}
        //public IActionResult OrderHistory(string? status)
        //{
        //    var userId = _userManager.GetUserId(User);
        //    List<UserOrderHeader> orderLists = new List<UserOrderHeader>();
        //    if (status != null && status != "All")
        //    {
        //        if (User.IsInRole("Admin"))
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status).ToList();
        //        }
        //        else
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status && u.UserId == userId).ToList();
        //        }
        //    }
        //    else
        //    {
        //        if (User.IsInRole("Admin"))
        //        {
        //            orderLists = _db.orderHeaders.ToList();
        //        }
        //        else
        //        {
        //            orderLists = _db.orderHeaders.Where(u => u.UserId == userId).ToList();
        //        }
        //        return View(orderLists);
        //    }
        //}




    }
}
