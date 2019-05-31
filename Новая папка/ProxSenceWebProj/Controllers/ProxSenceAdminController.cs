using System.Web.Mvc;
using System.Web;
using System.Linq;
using ProxSence.Library.InterfacesLibrary;
using ProxSence.Library.ProxSenceModels;

namespace ProxSenceWebProj.Controllers
{
    [Authorize]
    public class ProxSenceAdminController : Controller
    {
        private IPortfolioAdding CreateRepository;
        public ProxSenceAdminController(IPortfolioAdding portfolioAdding)
        {
            CreateRepository = portfolioAdding;
        }
        public ViewResult Index()
        {
            return View(CreateRepository.PList);
        }
        public ViewResult EditProject(int Id)
        {
            PortfolioList PList = CreateRepository.PList
                .FirstOrDefault(a => a.Id == Id);
            return View(PList);
        }
        [HttpPost]
        public ActionResult EditProject([Bind(Exclude = "images")] PortfolioList PList, HttpPostedFileBase images = null)
        {
            if (ModelState.IsValid)
            {
                if(images != null)
                {
                    PList.ImageType = images.ContentType;
                    PList.Images = new byte[images.ContentLength];
                    images.InputStream.Read(PList.Images, 0, images.ContentLength);
                }
                CreateRepository.SavePortfolioProject(PList);
                TempData["message"] = string.Format("{0} был успешно сохранен и добавлен в базу данных", PList.ProjectName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(PList);
            }
        }
        public ViewResult CreateProject([Bind(Exclude = "images")] HttpPostedFileBase images = null )
        {
            return View("EditProject", new PortfolioList());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            PortfolioList deletePortfolio = CreateRepository.DeletePortfolioInformation(Id);
            if(deletePortfolio != null)
            {
                TempData["message"] = string.Format("{0} был успешно удален", deletePortfolio.ProjectName);
            }
            return RedirectToAction("Index");
        }
    }
}