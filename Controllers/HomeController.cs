using POS_Minimart.Helper;
using POS_Minimart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace POS_Minimart.Controllers
{  

    
    public class HomeController : Controller
    {
        [AuthorizationFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult UserCreate()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public JsonResult CheckLogin(string username, string password)
        {
            POS_MiniMartEntities db = new POS_MiniMartEntities();
           
            var dataItem = db.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();         
            bool isLogged = true;
            if (dataItem != null)
            {
                Session["Username"] = dataItem.Username;
                Session["Role"] = dataItem.Role;
                isLogged = true;
            }
            else
            {
                isLogged = false;
            }
            return Json(isLogged, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveUser(User user)
        {
            POS_MiniMartEntities db = new POS_MiniMartEntities();
            bool isSuccess = true;
            try
            {
                user.Status = 1;
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            
            
            return Json(isSuccess, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetAllUser()
        {
            POS_MiniMartEntities db = new POS_MiniMartEntities();
            var dataList = db.Users.Where(x => x.Status == 1).ToList();

            return Json(dataList, JsonRequestBehavior.AllowGet);

        }


    }
}