using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context _context = new Context();
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add_Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Category(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges(); // ExeCuteNonQuery aquivalent to SaveChanges in ado.net
            return RedirectToAction("Index");
        }

        public ActionResult Destroy_Category(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update_Category(int id)
        {
            var category = _context.Categories.Find(id);
            return View("Update_Category", category);
        }

        public ActionResult Update_Post_Category(Category category)
        {
            var result = _context.Categories.Find(category.Id);
            result.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}