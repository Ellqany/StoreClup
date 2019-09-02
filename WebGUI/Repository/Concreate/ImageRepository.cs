using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class ImageRepository : IImageRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();
        public IEnumerable<Image> Images => Context.Images;

        public async Task<Image> DeleteImage(int ImageID)
        {
            Image dbEntry = await Context.Images.FindAsync(ImageID);
            if (dbEntry != null)
            {
                Context.Images.Remove(dbEntry);
                await Context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task SaveImage(Image Image)
        {
            if (Image.ImageId == 0)
            {
                Context.Images.Add(Image);
            }
            else
            {
                Image dbEntry = await Context.Images.FindAsync(Image.ImageId);
                if (dbEntry != null)
                {
                    dbEntry.Title = Image.Title;
                    dbEntry.Description = Image.Description;
                    dbEntry.ImageURL = Image.ImageURL;
                    dbEntry.Category = Image.Category;
                }
            }
            await Context.SaveChangesAsync();
        }
    }
}