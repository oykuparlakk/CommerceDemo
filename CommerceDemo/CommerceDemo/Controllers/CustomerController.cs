using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context _context = new Context();
        public ActionResult Index()
        {
            var customers = _context.Customers
                                        .Where(x => x.Status == true)
                                        .ToList();
            return View(customers);
        }


        [HttpGet]
        public ActionResult Add_Customer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add_Customer(Customer customer)
        {
            customer.Status = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_Customer(int id)
        {
            var customer = _context.Customers.Find(id);
            customer.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update_Customer(int id)
        {
            var customer = _context.Customers.Find(id);
            return View("Update_Customer", customer);

        }
        public ActionResult Update_Post_Customer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Update_Customer");
            }
            var customers = _context.Customers.Find(customer.Id);
            customers.CustomerName = customer.CustomerName;
            customers.Address = customer.Address;
            customers.Email = customer.Email;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Customer_SalesMove(int id)
        {
            var sales_move = _context.SalesMoves
                                        .Where(x => x.CustomerId == id)
                                        .ToList();
            var customer = _context.Customers
                                        .Where(x => x.Id == id)
                                        .Select(y => y.CustomerName)
                                        .FirstOrDefault();
            ViewBag.customer = customer;

            return View(sales_move);
        }
    }
}