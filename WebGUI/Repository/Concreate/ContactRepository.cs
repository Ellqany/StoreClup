using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class ContactRepository : IContactRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();

        public IEnumerable<Contact> Messages => Context.Contacts;

        public async Task<Contact> DeleteMessage(int MessageID)
        {
            Contact dbEntry = await Context.Contacts.FindAsync(MessageID);
            if (dbEntry != null)
            {
                Context.Contacts.Remove(dbEntry);
                await Context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task SendMessage(Contact Message)
        {
            Context.Contacts.Add(Message);
            await Context.SaveChangesAsync();
        }
    }
}