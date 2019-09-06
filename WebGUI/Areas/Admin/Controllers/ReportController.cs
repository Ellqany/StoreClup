using Microsoft.Reporting.WebForms;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebGUI.Areas.Admin.Controllers
{
    public class ReportController : GenericController
    {
        public ActionResult Product()
        {
            ReportViewer rp = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                Width = Unit.Percentage(100),
                Height = Unit.Percentage(100)
            };
            rp.LocalReport.ReportPath =
                    Request.MapPath(Request.ApplicationPath) + @"Reports/Products.rdl";
            ViewBag.ReportViewer = rp;
            return View();
        }

    }
}