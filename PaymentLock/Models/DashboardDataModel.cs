using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentLock.Models
{
    public class DashboardDataModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Groupname { get; set; }
        public string Venue { get; set; }
        public string Status { get; set; }
        public string DateOfEvent { get; set; }
        public int chargeAmount { get; set; }
    }
}