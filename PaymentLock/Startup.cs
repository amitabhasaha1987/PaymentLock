using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentLock.Startup))]
namespace PaymentLock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
