using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentLock.Controllers
{
    public class UnauthorizedController : Controller
    {
        //
        // GET: /Unauthorized/
        public ActionResult Access()
        {
            return View();
        }
	}
}