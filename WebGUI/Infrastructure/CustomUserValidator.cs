using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using WebGUI.Models;

namespace WebGUI.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager mgr)
            : base(mgr)
        {
        }
        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            return result;
        }
    }
}