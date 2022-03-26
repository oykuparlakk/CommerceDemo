using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context _context = new Context();
        public ActionResult Index()
        {
            var results = _context.Products.ToList();
            return View(results);
        }
    }
}