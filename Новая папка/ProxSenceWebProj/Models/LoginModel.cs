using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProxSenceWebProj.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}