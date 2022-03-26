using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context _context = new Context();
        public ActionResult Index()
        {
            ProductDetail pd = new ProductDetail();
            //var results = _context.Products.Where(x => x.Id == 1).ToList();
            pd.Products = _context.Products.Where(x => x.Id == 1).ToList();
            pd.Details = _context.Details.Where(x => x.DetailId == 1).ToList();
            return View(pd);
        }
    }
}