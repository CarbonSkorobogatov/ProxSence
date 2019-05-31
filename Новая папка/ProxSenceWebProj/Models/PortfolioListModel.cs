using System.Collections.Generic;
using ProxSence.Library.ProxSenceModels;

namespace ProxSenceWebProj.Models
{
    public class PortfolioListModel
    {
        public IEnumerable<PortfolioList> PList { get; set; }
        public PageBreakModel PageBreakModel { get; set; }
        public string Category { get; set; }
    }
}