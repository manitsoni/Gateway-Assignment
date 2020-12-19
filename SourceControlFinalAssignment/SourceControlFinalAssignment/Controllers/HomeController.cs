using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlFinalAssignment.Models;
namespace SourceControlFinalAssignment.Controllers
{
    public class HomeController : Controller
    {
        SourceControlEntities db = new SourceControlEntities();
        public ActionResult Index()
        {
            return View();
        }     
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserRegistration objUr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblRegistration objTr = new tblRegistration();
                    objTr.Createddate = DateTime.Now;
                    objTr.IsActive = true;
                    objTr.Email = objUr.Email;
                    objTr.Username = objUr.UserName;
                    objTr.Password = objUr.Password;
                    db.tblRegistrations.Add(objTr);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception _Ex)
            {
                string msg = "";
                return RedirectToAction("Error",msg = _Ex.Message);
            }
          
            
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin objUl)
        {
            try
            {
                var user = db.tblRegistrations.Where(m => m.Username == objUl.UserName && m.Password == objUl.Password && m.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    TempData["msg"] = "Login Success!";
                    return RedirectToAction("Index","UserDashboard");
                }
                else
                {
                    TempData["msg"] = "Invalid Crendentianls!";
                    return View();
                }
            }
            catch (Exception _Ex)
            {
                string msg = "";
                return RedirectToAction("Error", msg = _Ex.Message);
            }
        }
        public ActionResult Error(string ErrorMsg)
        {
            TempData["ErrorMsg"] = ErrorMsg;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}