using Microsoft.AspNet.Identity.EntityFramework;

namespace WebGUI.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {

        }
        public AppRole(string Name) : base(Name)
        {

        }

    }
}