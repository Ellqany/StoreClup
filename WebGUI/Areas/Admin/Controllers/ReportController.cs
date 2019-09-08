using Microsoft.AspNet.Identity.Owin;
using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGUI.Infrastructure;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class ReportController : GenericController
    {
        #region Private Variables
        readonly IReportRepository ReportRepository;
        AppUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        ReportViewer ReportViewer => new ReportViewer
        {
            ProcessingMode = ProcessingMode.Local,
            SizeToReportContent = true,
            ZoomMode = ZoomMode.Percent
        };
        #endregion

        #region Controller
        public ReportController(IReportRepository reportRepository) =>
            ReportRepository = reportRepository;
        #endregion

        public ActionResult Product()
        {
            ReportViewer rp = ReportViewer;
            rp.LocalReport.ReportPath =
                    Request.MapPath(Request.ApplicationPath) + @"Reports/Products.rdlc";
            rp.LocalReport.DataSources.
                Add(new ReportDataSource("Reports", ReportRepository.ProductsReport()));
            ViewBag.ReportViewer = rp;
            return View();
        }

        public ActionResult Financial()
        {
            ReportViewer rp = ReportViewer;
            rp.LocalReport.ReportPath =
                    Request.MapPath(Request.ApplicationPath) + @"Reports/Money.rdlc";
            rp.LocalReport.DataSources.
                Add(new ReportDataSource("Money", ReportRepository.FinancialReport()));
            ViewBag.ReportViewer = rp;
            return View();
        }

        public ActionResult Users()
        {
            ReportViewer rp = ReportViewer;
            rp.LocalReport.ReportPath =
                    Request.MapPath(Request.ApplicationPath) + @"Reports/Users.rdlc";
            rp.LocalReport.DataSources.
                Add(new ReportDataSource("UserReport", ReportRepository.UsersReport()));
            rp.LocalReport.DataSources.
                Add(new ReportDataSource("Users", UserManager.Users.ToList()));
            ViewBag.ReportViewer = rp;
            return View();
        }

    }
}