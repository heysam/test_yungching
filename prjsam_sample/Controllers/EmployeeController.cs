using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjsam_sample.Models;

namespace prjsam_sample.Controllers
{
    public class EmployeeController : Controller
    {
        dbEmpEntities1 db = new dbEmpEntities1();
        [Authorize]
        // GET: Employee
        public ActionResult Index()
        {
            var emps = db.tEmployee.OrderByDescending(m => m.fId).ToList();
            return View(emps);
        }

        
        [Authorize]
        // GET: Employee
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(string fName, string fPhone, int fSalary, string 帳號, string 密碼)
        {
            tEmployee emp = new tEmployee();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            emp.帳號 = 帳號;
            emp.密碼 = 密碼;
            db.tEmployee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int fId)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int fId, string fName, string fPhone, int fSalary, string 帳號, string 密碼)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            emp.帳號 = 帳號;
            emp.密碼 = 密碼;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int fId)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}