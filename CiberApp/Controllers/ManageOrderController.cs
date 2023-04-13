using Microsoft.AspNetCore.Mvc;
using DAL.EntityFramework;
using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Serilog;

namespace CiberApp.Controllers
{
    public class ManageOrderController : Controller
    {
        public async Task<IActionResult> GetListOrderByPage(int? page_num, string textSearch)
        {
            string username = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Login");
            }
            var data = new ListOrderModel();
            var orderModel = new OrderModel();
            var productModel = new ProductModel();
            var customerModel = new CustomerModel();
            var listOrders = orderModel.ListAllOrders(textSearch);
            var listProducts = productModel.ListAllProducts();
            var listCustomers = customerModel.ListAllCustomers();
            var listOrdersByPage = listOrders.Select((x,Index) => new OrderViewModel()
            { 
                Stt = Index+1,
                OrderId = x.OrderId,
                ProductName = x.ProductName,
                CategoryName = x.CategoryName,
                CustomerName = x.CustomerName,
                OrderDate = x.OrderDate,
                Amount = x.Amount,
            }).Skip((page_num.GetValueOrDefault(1) - 1) * 10).Take(10).ToList();
            data.textSearch = textSearch;
            data.ListProducts = listProducts;
            data.ListCustomers = listCustomers;
            data.ListOrders = listOrdersByPage;
            data.page_active = page_num.GetValueOrDefault(1);
            data.CountAll = listOrders.Count();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewOrder(CreateNewOrderModel entity)
        {
                var orderModel = new OrderModel();
                var resurt = orderModel.CreateNewOrder(entity);
                if(resurt == 1)
                {
                    return Json(new { status = 1, message = "Success!!!" });
                }
                else
                {
                    return Json(new { status = 0, message = "Fail!!!" });
                }    
        }
    }
}
