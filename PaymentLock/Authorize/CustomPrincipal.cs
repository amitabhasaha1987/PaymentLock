using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DataAccess;

namespace PaymentLock.Authorize
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public DataAccess.UserType role { get; set; }

        public System.Security.Principal.IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            return false; //for now
        }

    }
}