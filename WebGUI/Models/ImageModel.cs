using System.Web;
using WebGUI.App_Data;

namespace WebGUI.Models
{
    public class ImageModel : Image
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}