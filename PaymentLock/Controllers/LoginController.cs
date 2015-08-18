using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PaymentLock.Models;
using PaymentLock.Authorize;
using System.Web.Script.Serialization;
using System.Web.Security;
using DataAccess;


namespace PaymentLock.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(UserModel user)
        {

            if (ModelState.IsValid)
            {
                if (user.UserName == "admin@admin.com" && user.Password.Trim() == "admin@123")
                {
                    //Session["UserId"] = user.UserName;
                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.Id = 1;//user.Id;
                    //serializeModel.FirstName = user.UserName;
                    //serializeModel.LastName = user.LastName;
                    serializeModel.UserName = user.UserName;
                    serializeModel.role = DataAccess.UserType.Admin;


                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string userData = serializer.Serialize(serializeModel);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                                             1,
                                                             user.UserName,
                                                             DateTime.Now,
                                                             DateTime.Now.AddMinutes(30),
                                                             false,
                                                             userData);
                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);


                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Flag = false;
                    return View(user);

                }

            }
            ViewBag.Flag = false;
            return View(user);
        }
        
        //Logout
        [AuthorizeAccess(UserType.Admin,UserType.Client,UserType.Customer)]

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LoginUser", "Login");
        }
    }
}