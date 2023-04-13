using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace CiberApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel entity)
        {
            var resurl = new AccountModel().Login(entity.UserName, entity.Password);
            if(resurl && ModelState.IsValid)
            {
                HttpContext.Session.SetString("UserName", entity.UserName);
                return RedirectToAction("GetListOrderByPage", "ManageOrder");
            }   
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng");
            }    
            return View(entity);
        }
    }
}
