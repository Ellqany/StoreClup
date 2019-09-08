using System.Collections.Generic;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IReportRepository
    {
        IEnumerable<Report_Products_Result> ProductsReport();
        IEnumerable<Report_Financials_Result> FinancialReport();
        IEnumerable<Report_Users_Result> UsersReport();
    }
}
