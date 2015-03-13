using System.ComponentModel.DataAnnotations;
using MvcCaptcha;

namespace MvcCaptchaProject.Models
{
    public class User
    {
        [Required]
        [ValidateCaptcha(ErrorMessageResourceName = "WrongCaptcha", ErrorMessageResourceType = typeof(Res))]
        [Display(Name = "Captcha", ResourceType = typeof(Res))]
        [UIHint("captcha")]
        public string Captcha { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Res))]
        public string Name { get; set; }
    }
}