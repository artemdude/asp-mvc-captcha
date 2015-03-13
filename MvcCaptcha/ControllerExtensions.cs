using System.Web.Mvc;

namespace MvcCaptcha
{
    public static class ControllerExtensions
    {
        public static CaptchaResult Captcha(this Controller controller)
        {
            return Captcha(controller, new CaptchaImage());
        }

        public static CaptchaResult Captcha(this Controller controller, ICaptchaImage captchaImage, int quality = 100, int width = 120, int height = 35 )
        {
            var captchaValue = captchaImage as ICaptchaValue;
            if (captchaValue != null)
                controller.Session[CaptchaConstants.CaptchaUniqueIdPrefix + captchaImage.CaptchaUniqueId] = captchaValue.RenderedValue;
            return new CaptchaResult(captchaImage, quality, width, height);
        }
    }
}
