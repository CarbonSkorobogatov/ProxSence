using System.Collections.Generic;
using ProxSence.Library.ProxSenceModels;

namespace ProxSence.Library.InterfacesLibrary
{
    public interface IPortfolioAdding
    {
        IEnumerable<PortfolioList> PList { get; }
        void SavePortfolioProject(PortfolioList PList);
        PortfolioList DeletePortfolioInformation(int Id);
    }
}
