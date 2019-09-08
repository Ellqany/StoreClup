using System.Collections.Generic;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class ReportRepository : IReportRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();

        public IEnumerable<Report_Financials_Result> FinancialReport() =>
            Context.Report_Financials();

        public IEnumerable<Report_Products_Result> ProductsReport() =>
            Context.Report_Products();

        public IEnumerable<Report_Users_Result> UsersReport() =>
            Context.Report_Users();
    }
}