using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WepUI.Repository
{
    public interface IMailConfirmation
    {
        Task SendMessage(IdentityMessage message);
    }
}
