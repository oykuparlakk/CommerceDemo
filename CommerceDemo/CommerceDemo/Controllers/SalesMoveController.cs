using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class SalesMoveController : Controller
    {
        // GET: SalesMove
        Context _context = new Context();
        public ActionResult Index()
        {
            var sales_move = _context.SalesMoves.ToList();
            return View(sales_move);
        }
        [HttpGet]
        public ActionResult Add_SalesMove()
        {
            List<SelectListItem> productList = (from x in _context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            List<SelectListItem> customerList = (from x in _context.Customers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CustomerName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            List<SelectListItem> employeeList = (from x in _context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.employeeList = employeeList;
            ViewBag.customerList = customerList;
            ViewBag.productList = productList;
            return View();
        }

        [HttpPost]
        public ActionResult Add_SalesMove(SalesMove salesMove)
        {
            salesMove.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SalesMoves.Add(salesMove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update_SalesMove(int id)
        {
            List<SelectListItem> productList = (from x in _context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            List<SelectListItem> customerList = (from x in _context.Customers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CustomerName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            List<SelectListItem> employeeList = (from x in _context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.employeeList = employeeList;
            ViewBag.customerList = customerList;
            ViewBag.productList = productList;
            var salesmove = _context.SalesMoves.Find(id);
            return View("Update_SalesMove", salesmove);
        }
        public ActionResult Update_Post_SalesMove(SalesMove salesMove)
        {
            var _salesMove = _context.SalesMoves.Find(salesMove.Id);
            _salesMove.ProductId = salesMove.ProductId;
            _salesMove.CustomerId = salesMove.CustomerId;
            _salesMove.EmployeeId = salesMove.EmployeeId;
            _salesMove.Amount = salesMove.Amount;
            _salesMove.Price = salesMove.Price;
            _salesMove.TotalPrice = salesMove.TotalPrice;
            _salesMove.Date = salesMove.Date;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Detail_SalesMove(int id)
        {
            var result = _context.SalesMoves
                                           .Where(x => x.Id == id)
                                           .ToList();
            return View(result);
        }


    }
}