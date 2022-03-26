using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context _context = new Context();
        public ActionResult Index()
        {
            var deger1 = _context.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = _context.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = _context.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = _context.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = _context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in _context.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = _context.Products.Count(x => x.Stock<=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in _context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in _context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = _context.Products.Where(u=>u.Id==(_context.SalesMoves.GroupBy(x => x.ProductId)
                                             .OrderByDescending(z => z.Count())
                                             .Select(y => y.Key)
                                             .FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d10= deger10;

            var deger11 = _context.SalesMoves.Sum(x => x.TotalPrice).ToString();
            ViewBag.d11 = deger11;

            DateTime today = DateTime.Today;
            var deger12 = _context.SalesMoves.Count(x => x.Date ==today).ToString();
            ViewBag.d12 = deger12;
            return View();
        }


        public ActionResult SimpleTables()
        {
            var request = from x in _context.Customers
                          group x by x.Address into info
                          select new CustomerAddress
                          {
                              City = info.Key,
                              TotalNumber=info.Count()
                          };
            return View(request.ToList());
        }
        public PartialViewResult Partial1()
        {
            var request = from x in _context.Employees
                          group x by x.Department.Name into info
                          select new EmployeeDepartment
                          {
                             DepartmanId = info.Key,
                             Total=info.Count()
                          };

            return PartialView(request.ToList());
        }
        public PartialViewResult Partial2()
        {
            var request = _context.Customers.ToList();
            return PartialView(request);
        }
        public PartialViewResult Partial3()
        {
            var request = _context.Products.ToList();
            return PartialView(request);
        }
        public PartialViewResult Partial4()
        {
            var request = from x in _context.Products
                          group x by x.ProductBrand into info
                          select new ProductBrand
                          {
                              Brand =info.Key,
                              Total=info.Count()
                          };
            return PartialView(request.ToList());
            
        }
    }
}