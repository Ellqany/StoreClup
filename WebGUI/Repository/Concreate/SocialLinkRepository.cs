using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class SocialLinkRepository : ISocialLinkRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();
        public IEnumerable<SocialLink> SocialLinks => Context.SocialLinks;

        public async Task SaveLink(SocialLink Link)
        {
            if (Link.id == 0)
            {
                Context.SocialLinks.Add(Link);
            }
            else
            {
                SocialLink dbEntry = await Context.SocialLinks.FindAsync(Link.id);
                if (dbEntry != null)
                {
                    dbEntry.id = Link.id;
                    dbEntry.Link = Link.Link;
                    dbEntry.Category = Link.Category;
                }
            }
            await Context.SaveChangesAsync();
        }

    }
}