using System.Collections.Generic;
using WebGUI.App_Data;

namespace WebGUI.Areas.Admin.Models
{
    public class OrderModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public string Search { get; set; }
    }
}