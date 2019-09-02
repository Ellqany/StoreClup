using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Messages { get; }
        Task SendMessage(Contact Message);
        Task<Contact> DeleteMessage(int MessageID);
    }
}
