using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProxSence.Library.InterfacesLibrary;

namespace ProxSenceWebProj.Controllers
{
    public class NavigationController : Controller
    {
        private IPortfolioAdding CreateRepository;

        public NavigationController(IPortfolioAdding portfolioAdding)
        {
            CreateRepository = portfolioAdding;
        }
        public PartialViewResult NavigationMenu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = CreateRepository.PList
                .Select(a => a.ProjectCategory)
                .Distinct()
                .OrderBy(a => a);
            return PartialView(categories);
        }
    }
}