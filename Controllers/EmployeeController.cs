using FirstCrudMVV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstCrudMVV.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var employeeList = _dbContext.Employees.ToList();
            ViewBag.Employees = employeeList;
            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee(int? id)
        {
            var record = _dbContext.Employees.FirstOrDefault(m => m.Id == id);
            if (record != null && id > 0)
            {
                return View(record);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SaveEmployee(Employee model)
        {
            if (model.Id > 0)
            {
                var record = _dbContext.Employees.FirstOrDefault(m => m.Id == model.Id);
                if (record != null)
                {
                    record.Name = model.Name;
                    record.Designation = model.Designation;
                    record.Salary = model.Salary;
                    _dbContext.SaveChanges();
                }
            }
            else
            {
                _dbContext.Employees.Add(model);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var record = _dbContext.Employees.FirstOrDefault(m => m.Id == id);
                _dbContext.Employees.Remove(record);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}