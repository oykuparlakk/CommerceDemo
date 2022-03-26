using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class TodoListController : Controller
    {
        // GET: TodoList
        Context _context = new Context();
        public ActionResult Index()
        {
            var request1 = _context.Customers.Count().ToString();
            ViewBag.request1 = request1;
            var request2 = _context.Products.Count().ToString();
            ViewBag.request2 = request2;
            var request3 = _context.Categories.Count().ToString();
            ViewBag.request3 = request3;
            var request4 = (from x in _context.Customers select x.Address)
                                              .Distinct()
                                              .Count()
                                              .ToString();
            ViewBag.request4 = request4;


            var ToDoList = _context.TodoLists.ToList();
            return View(ToDoList);
        }
    }
}