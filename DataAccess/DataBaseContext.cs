using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess 
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("PaymentLock")
        {

        }
    }
}
