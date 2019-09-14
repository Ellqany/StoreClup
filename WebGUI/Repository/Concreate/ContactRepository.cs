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
            if (Message.ContactId == 0)
            {
                Context.Contacts.Add(Message);
            }
            else
            {
                Contact dbEntry = await Context.Contacts.FindAsync(Message.ContactId);
                if (dbEntry != null)
                {
                    dbEntry.Name = Message.Name;
                    dbEntry.Email = Message.Email;
                    dbEntry.Massage = Message.Massage;
                    dbEntry.Phone = Message.Phone;
                    dbEntry.Subject = Message.Subject;
                }
            }
            await Context.SaveChangesAsync();
        }
    }
}