using Microsoft.AspNet.Identity.Owin;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Areas.Admin.Models;
using WebGUI.Infrastructure;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class ReportController : GenericController
    {
        #region Private Variables
        readonly IReportRepository ReportRepository;
        readonly IProductRepository ProductRepository;
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
        public ReportController(
            IReportRepository reportRepository,
            IProductRepository Productrepo)
        {
            ReportRepository = reportRepository;
            ProductRepository = Productrepo;
        }
        #endregion

        public async Task<ActionResult> Product()
        {
            var ProductReport = ReportRepository.ProductsReport();
            return View(await GetProductSallesDetails(ProductReport));
        }

        public ActionResult ProductReport()
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
            var FinancialReport = ReportRepository.FinancialReport();
            return View(FinancialReport.ToList());
        }

        public ActionResult FinancialReport()
        {
            ReportViewer rp = ReportViewer;
            rp.LocalReport.ReportPath =
                    Request.MapPath(Request.ApplicationPath) + @"Reports/Money.rdlc";
            rp.LocalReport.DataSources.
                Add(new ReportDataSource("Money", ReportRepository.FinancialReport()));
            ViewBag.ReportViewer = rp;
            return View();
        }

        public async Task<ActionResult> Users()
        {
            var UsersReport = ReportRepository.UsersReport();
            return View(await GetUsersReport(UsersReport.ToList()));
        }

        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "user has beed deleted successfully";
            }
            var UsersReport = ReportRepository.UsersReport();
            var users = await GetUsersReport(UsersReport.ToList());
            return PartialView("GetUsers", users);
        }

        public ActionResult UsersReport()
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

        #region Private Methods
        public async Task<List<ProductSallesDetails>> GetProductSallesDetails
            (IEnumerable<Report_Products_Result> report)
        {
            var task = Task.Factory.StartNew(() =>
            {
                List<ProductSallesDetails> Result = new List<ProductSallesDetails>();
                foreach (var item in report)
                {
                    Result.Add(new ProductSallesDetails
                    {
                        Name = item.Name,
                        SumQuantity = item.SumQuantity,
                        Product = ProductRepository.Products.Where(x => x.Name == item.Name).FirstOrDefault()
                    });
                }
                return Result.OrderByDescending(x => x.SumQuantity).ToList();
            });
            await task;
            return task.Result;
        }

        public async Task<List<UsersReport>> GetUsersReport
            (List<Report_Users_Result> report)
        {
            var task = Task.Factory.StartNew(() =>
           {
               var users = UserManager.Users;
               List<UsersReport> Result = new List<UsersReport>();
               foreach (var item in users)
               {
                   var userreport = report.Where(x => x.Email == item.Email).FirstOrDefault();
                   Result.Add(new UsersReport
                   {
                       Name = item.Name,
                       TotalOrder = userreport?.TotalOrder,
                       Email = item.Email,
                       User = item
                   });
               }
               return Result.OrderByDescending(x => x.TotalOrder).ToList();
           });
            await task;
            return task.Result;
        }
        #endregion
    }
}