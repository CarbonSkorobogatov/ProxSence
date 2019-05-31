using ProxSence.Library.InterfacesLibrary;
using System.Web.Security;

namespace ProxSenceWebProj.ProjectInfrastructure
{
    public class AutorizationForms : IAutorization
    {
        public bool AutorizationSuccess(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}