using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WebGUI.Repository
{
    public interface IMailConfirmation
    {
        Task SendMessage(IdentityMessage message);
    }
}
