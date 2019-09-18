using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class PageRepository : IPageRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();

        public IEnumerable<Page> Pages => Context.Pages;

        public async Task SavePage(Page Page)
        {
            if (Page.Id == 0)
            {
                Context.Pages.Add(Page);
            }
            else
            {
                Page dbEntry = await Context.Pages.FindAsync(Page.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = Page.Title;
                    dbEntry.Description = Page.Description;
                    dbEntry.Category = Page.Category;
                }
            }
            await Context.SaveChangesAsync();
        }
    }
}