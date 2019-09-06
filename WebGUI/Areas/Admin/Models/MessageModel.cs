using System.Collections.Generic;
using WebGUI.App_Data;

namespace WebGUI.Areas.Admin.Models
{
    public class MessageModel
    {
        public IEnumerable<Contact> Messages { get; set; }
        public string Search { get; set; }
    }
}