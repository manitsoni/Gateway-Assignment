using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlFinalAssignment.Models;
using System.IO;

namespace SourceControlFinalAssignment.Controllers
{
    public class UserDashboardController : Controller
    {
        SourceControlEntities db = new SourceControlEntities();
        // GET: UserDashboard
        public ActionResult Index()
        {
            ViewBag.UserList = db.tblUserDetails.Where(m => m.IsActive == true).ToList();
            return View();
        }
        public ActionResult AddUser()
        {
            try
            {
                return View();
            }
            catch (Exception _Ex)
            {
                string message = _Ex.Message;
                return RedirectToAction("Error", message);
            }
        }
        [HttpPost]
        public ActionResult AddUser(AddUser objUser)
        {
            try
            {
               
                string filename = Path.GetFileNameWithoutExtension(objUser.ImageFile.FileName);
                string extension = Path.GetExtension(objUser.ImageFile.FileName);

                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

                var temp = filename;
                objUser.ProductImage = "~/UserImage/" + filename;

                filename = Path.Combine(Server.MapPath("~/UserImage/"), filename);
                objUser.ImageFile.SaveAs(filename);
                tblUserDetail objUd = new tblUserDetail();
                objUd.Photo = temp;
                objUd.IsActive = true;
                string fname = objUser.FirstName;
                string mname = objUser.MiddleName;
                string lname = objUser.LastName;
                fname = fname.First().ToString().ToUpper() + fname.Substring(1);
                mname = mname.First().ToString().ToUpper() + mname.Substring(1);
                lname = lname.First().ToString().ToUpper() + lname.Substring(1);
                string name = fname + mname + lname;
                objUd.Name = name;
                objUd.Pincode = objUser.Pincode;
                objUd.State = objUser.State;
                objUd.Email = objUser.Email;
                objUd.CreditcardNumber = objUser.CreditCardNumber;
                objUd.Createddate = DateTime.Now;
                objUd.Country = objUser.Country;
                objUd.City = objUser.City;
                objUd.AddressLine2 = objUser.AdresLine2;
                objUd.AddressLine1 = objUser.AdressLine1;
                db.tblUserDetails.Add(objUd);
                if(db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Data Added Successfully!!!!!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception _Ex)
            {
                string message = _Ex.Message;
                return RedirectToAction("Error", message);
            }
        }
        public ActionResult Error(string mess)
        {
            ViewBag.message = mess;
            return View();
        }
        public ActionResult DisplayUser(int? id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}