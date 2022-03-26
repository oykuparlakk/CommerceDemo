using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CommerceDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context _context = new Context();
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult CustomerRegisterPartial()//Partial1
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CustomerRegisterPartial(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var info = _context.Customers.FirstOrDefault(x => x.Email == customer.Email && x.Password == customer.Password);
            if(info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Email, false);
                Session["Email"] = info.Email.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }
    }
}