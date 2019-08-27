using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebGUI.Models;

namespace WebGUI.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("trialAccount") { }
        static AppIdentityDbContext()
        {
            using (AppIdentityDbContext Context = new AppIdentityDbContext())
            {
                Context.Database.CreateIfNotExists();
            }
        }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
    {
    }
}