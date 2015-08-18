using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace PaymentLock.Authorize
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAccess : AuthorizeAttribute
    {
        public AuthorizeAccess(params UserType[] roles)
        {

            this.Roles = roles;

        }
        public UserType[] Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            CustomPrincipal Principal = (HttpContext.Current.User as CustomPrincipal);
            if (Principal != null)
            {
                UserType userrole = (UserType)(Convert.ToByte(Principal.role));
                if (Array.Exists(Roles, e => e == userrole))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
            //filterContext.Result = new RedirectToRouteResult(new
            //System.Web.Routing.RouteValueDictionary(new { controller = "UserLogin", action = "Login" }));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            CustomPrincipal Principal = (HttpContext.Current.User as CustomPrincipal);
            if (Principal != null)
            {
                filterContext.Result = new RedirectResult("/Unauthorized/Access");
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login/LoginUser");
            }

        }
    }
}