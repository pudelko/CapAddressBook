using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAddressBook.Startup))]
namespace TestAddressBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
