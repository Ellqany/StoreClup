using System.Web;
using WebGUI.App_Data;
using WebGUI.Infrastructure;

namespace WebGUI.Models
{
    public class ImageModel : Image
    {
        [ImageValidation("ImageURL")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}