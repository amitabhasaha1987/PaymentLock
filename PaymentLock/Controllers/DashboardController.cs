using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentLock.Models;
using PaymentLock.Authorize;
using DataAccess;

namespace PaymentLock.Controllers
{
    public class DashboardController : BaseController
    {
        //
        // GET: /Dashboard/
        [AuthorizeAccess(UserType.Admin,UserType.Client)]
        public ActionResult Index()
        {
            List<DashboardDataModel> objListDataDshBoardData = new List<DashboardDataModel>();
            DashboardDataModel objDashboardDataModel = new DashboardDataModel();
            objDashboardDataModel.Id = 1;
            objDashboardDataModel.Order = 527;
            objDashboardDataModel.Name = "runhao zeng";
            objDashboardDataModel.Groupname = "runhao zeng";
            objDashboardDataModel.Venue = "CREATE NIGHTCLUB";
            objDashboardDataModel.Status = "Pending";
            objDashboardDataModel.DateOfEvent = "07/31/2015";
            objDashboardDataModel.chargeAmount = 5412;

            DashboardDataModel objDashboardDataModelscnd = new DashboardDataModel();
            objDashboardDataModelscnd.Id = 2;
            objDashboardDataModelscnd.Order = 546;
            objDashboardDataModelscnd.Name = "Arman Sarafyan";
            objDashboardDataModelscnd.Groupname = "Mystrey";
            objDashboardDataModelscnd.Venue = "THE LIBRARY";
            objDashboardDataModelscnd.Status = "Pending";
            objDashboardDataModelscnd.DateOfEvent = "07/31/2015";
            objDashboardDataModelscnd.chargeAmount = 400;

            objListDataDshBoardData.Add(objDashboardDataModel);
            objListDataDshBoardData.Add(objDashboardDataModelscnd);
            return View(objListDataDshBoardData);
            return View(objListDataDshBoardData);
           
        }
	}
}