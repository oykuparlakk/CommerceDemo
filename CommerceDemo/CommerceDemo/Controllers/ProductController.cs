using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context _context = new Context();
        public ActionResult Index()
        {
            var products = _context.Products
                                        .Where(x => x.Status == true)
                                        .ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Add_Product()
        {
            List<SelectListItem> products = (from x in _context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.Id.ToString()

                                             }).ToList();
            ViewBag.product = products;
            return View();
        }

        [HttpPost]
        public ActionResult Add_Product(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete_Product(int id)
        {
            var result = _context.Products.Find(id);
            result.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update_Product(int id)
        {
            List<SelectListItem> products = (from x in _context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.Id.ToString()

                                             }).ToList();
            ViewBag.product = products;
            var product = _context.Products.Find(id);
            return View("Update_Product", product);
        }

        public ActionResult Update_Post_Product(Product product)
        {
            var products = _context.Products.Find(product.Id);
            products.ProductBrand = product.ProductBrand;
            products.ProductImage = product.ProductImage;
            products.ProductName = product.ProductName;
            products.SalePrice = product.SalePrice;
            products.SalesMoves = product.SalesMoves;
            products.Status = product.Status;
            products.Stock = product.Stock;
            products.CategoryId = product.CategoryId;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ProductList()
        {
            var list = _context.Products.ToList();
            return View(list);
        }
    }
}