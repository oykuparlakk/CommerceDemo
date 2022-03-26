using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context _context = new Context();
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Add_Employee()
        {
            List<SelectListItem> employees = (from x in _context.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.Id.ToString()

                                              }).ToList();
            ViewBag.employees = employees;
            return View();
        }
        [HttpPost]
        public ActionResult Add_Employee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update_Employee(int id)
        {
            List<SelectListItem> employees_department = (from x in _context.Departments.ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.Id.ToString()

                                                         }).ToList();
            ViewBag.employees_department = employees_department;
            var employee = _context.Employees.Find(id);
            return View("Update_Employee", employee);
        }

        public ActionResult Update_Post_Employee(Employee employee)
        {
            var result = _context.Employees.Find(employee.Id);
            result.EmployeeName = employee.EmployeeName;
            result.EmployeeImage = employee.EmployeeImage;
            result.DepartmentId = employee.DepartmentId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail_Employee()
        {
            var request = _context.Employees.ToList();
            return View(request);
        }
    }
}