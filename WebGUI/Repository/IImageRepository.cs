using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IImageRepository
    {
        IEnumerable<Image> Images { get; }
        Task SaveImage(Image Image);
        Task<Image> DeleteImage(int ImageID);
    }
}