using System.ComponentModel.DataAnnotations;
using System.Web;
using WebGUI.App_Data;

namespace WebGUI.Models
{
    public class ImageModel : Image
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Upload an image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}