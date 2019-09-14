using WebGUI.App_Data;
using WebGUI.Models;

namespace WebGUI.Areas.Admin.Models
{
    public class UsersReport : Report_Users_Result
    {
        public AppUser User { get; set; }
    }
}