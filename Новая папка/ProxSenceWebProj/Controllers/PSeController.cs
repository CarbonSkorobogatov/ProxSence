using System.Web.Mvc;
using ProxSenceWebProj.Models;
using ProxSence.Library.ProxSenceModels;
using ProxSence.Library.InterfacesLibrary;

namespace ProxSenceWebProj.Controllers
{
    public class PSeController : Controller
    {
        //Домашняя страница
        public ViewResult Index()
        {
            return View();
        }
        
        public ViewResult About()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return Redirect(Url.Action("Portfolio", "Portfolio"));
        }

        public ViewResult Contact()
        {
            return View(new FeedbackModel());
        }

	}
}