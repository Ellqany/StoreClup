using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebGUI.Models;

namespace WebGUI.Infrastructure
{
    public class AppRoleManager : RoleManager<AppRole>
    {
        public AppRoleManager(IRoleStore<AppRole, string> store) : base(store)
        {
        }
        public static AppRoleManager Create(
            IdentityFactoryOptions<AppRoleManager> Options,
            IOwinContext Context)
        {
            return new AppRoleManager(new
                RoleStore<AppRole>(Context.Get<AppIdentityDbContext>()));
        }

    }
}