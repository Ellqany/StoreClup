using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface ISocialLinkRepository
    {
        IEnumerable<SocialLink> SocialLinks { get; }
        Task SaveLink(SocialLink Link);
    }
}
