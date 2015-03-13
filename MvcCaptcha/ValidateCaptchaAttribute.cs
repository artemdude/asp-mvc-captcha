using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MvcCaptcha
{
    public class ValidateCaptchaAttribute : ValidationAttribute
    {
        public string CaptchaUniqueId { get; set; }

        public override bool IsValid(object value)
        {
            var userValue = value as string;
            var correctValue = HttpContext.Current.Session[CaptchaConstants.CaptchaUniqueIdPrefix + CaptchaUniqueId] as string;
            HttpContext.Current.Session.Remove(CaptchaConstants.CaptchaUniqueIdPrefix + CaptchaUniqueId);
            return userValue == correctValue;
        }
    }
}
