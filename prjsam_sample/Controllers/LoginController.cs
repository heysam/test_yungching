using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjsam_sample.Models;
using System.Web.Security;
namespace prjsam_sample.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string 帳號, string 密碼)
        {
            dbEmpEntities1 db = new dbEmpEntities1();
            var member =db.tEmployee
                .Where(m => m.帳號 == 帳號 && m.密碼 == 密碼)
                .FirstOrDefault();
            if (member !=null)
            {
                FormsAuthentication.RedirectFromLoginPage
                    (member.帳號, true);
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.IsLogin = true;
            return View();
        }
            
    }
}