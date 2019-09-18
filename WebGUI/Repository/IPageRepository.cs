using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IPageRepository
    {
        IEnumerable<Page> Pages { get; }
        Task SavePage(Page Page);
    }
}
