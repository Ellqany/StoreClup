using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebGUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenericController : Controller
    {
        #region Protected Methods
        protected async Task<string> CreateFileUrl(HttpPostedFileBase Image, string url)
        {
            var task = Task.Factory.StartNew<string>(() =>
            {
                if (Image != null)
                {
                    url = null;
                    string Name = Path.GetFileNameWithoutExtension(Image.FileName);
                    string Extention = Path.GetExtension(Image.FileName);
                    string URL = Name + DateTime.Now.ToString("yymmssfff") + Extention;
                    url = "/Images/" + URL;
                    Name = Path.Combine(Server.MapPath("~/Images"), URL);
                    Image.SaveAs(Name);
                }
                return url;
            });
            await task;
            return task.Result;
        }
        #endregion
    }
}