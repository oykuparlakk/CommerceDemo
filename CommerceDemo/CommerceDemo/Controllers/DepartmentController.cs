using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context _context = new Context();
        public ActionResult Index()
        {
            var departments = _context.Departments
                                       .Where(x => x.Status == true)
                                       .ToList();
            return View(departments);

        }
        [HttpGet]
        public ActionResult Add_Department()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_Department(Department department)
        {
            department.Status = true;
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete_Department(int id)
        {
            var department = _context.Departments.Find(id);
            department.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Update_Department(int id)
        {
            var department = _context.Departments.Find(id);
            return View("Update_Department", department);
        }

        public ActionResult Update_Post_Department(Department department)
        {
            var departments = _context.Departments.Find(department.Id);
            departments.Name = department.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail_Department(int id)
        {
            var result = _context.Employees
                                            .Where(x => x.DepartmentId == id)
                                            .ToList();
            var department = _context.Departments
                                            .Where(x => x.Id == id)
                                            .Select(y => y.Name)
                                            .FirstOrDefault();
            ViewBag.DepartmentName = department;
            return View(result);

        }

        public ActionResult Department_Employee_SalesMove(int id)
        {
            var result = _context.SalesMoves
                                            .Where(x => x.EmployeeId == id)
                                            .ToList();
            var employee = _context.Employees
                                            .Where(x => x.Id == id)
                                            .Select(y => y.EmployeeName )
                                            .FirstOrDefault();
            ViewBag.employee = employee;
            return View(result);
        }
    }
}