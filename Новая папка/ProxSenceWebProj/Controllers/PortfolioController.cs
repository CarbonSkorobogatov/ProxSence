using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProxSenceWebProj.Models;
using ProxSence.Library.ProxSenceModels;
using ProxSence.Library.InterfacesLibrary;

namespace ProxSenceWebProj.ProjectInfrastructure
{
    public class PortfolioController : Controller
    {
        private IPortfolioAdding CreateRepository;
        public int PageBreaking = 6;
        public PortfolioController(IPortfolioAdding portfolioAdding)
        {
            this.CreateRepository = portfolioAdding;
        }
        public ViewResult Portfolio(string category, int page = 1)
        {
            PortfolioListModel model = new PortfolioListModel
            {
                PList = CreateRepository.PList
                .Where(p => category == null || p.ProjectCategory == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageBreaking)
                .Take(PageBreaking),
                PageBreakModel = new PageBreakModel
                {
                    Page = page,
                    TotalProjectsPerPage = PageBreaking,
                    AllProjectsCategory = category == null ?
                        CreateRepository.PList.Count() :
                        CreateRepository.PList.Where(b => b.ProjectCategory == category).Count()
                },
                Category = category

            };
            return View(model);

        }
        public FileContentResult GetImages(int Id)
        {
            PortfolioList portfoliolist = CreateRepository.PList.FirstOrDefault(a => a.Id == Id);
            if(portfoliolist != null)
            {
                return File(portfoliolist.Images, portfoliolist.ImageType);
            }
            else
            {
                return null;
            }
        }
    }
}