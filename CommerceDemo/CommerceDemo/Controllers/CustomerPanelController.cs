using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class CustomerPanelController : Controller
    { 
        Context _context = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var email = (string)Session["Email"];
            var values = _context.Customers.FirstOrDefault(x => x.Email == email);
            ViewBag.m = email;
            return View(values);
        }
    }
}