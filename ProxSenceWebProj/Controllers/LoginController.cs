using System.Web.Mvc;
using ProxSenceWebProj.ProjectInfrastructure;
using ProxSenceWebProj.Models;
using ProxSence.Library.InterfacesLibrary;

namespace ProxSenceWebProj.Controllers
{
    public class LoginController : Controller
    {
        IAutorization autorization;
        public LoginController(IAutorization autorize)
        {
            autorization = autorize;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (autorization.AutorizationSuccess(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "ProxSenceAdmin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            
            else
            {
                return View();
            }            
        }
    }
}