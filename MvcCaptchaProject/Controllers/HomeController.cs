using System.Web.Mvc;
using MvcCaptcha;
using MvcCaptchaProject.Models;

namespace MvcCaptchaProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return Content("Success");
        }

        public ActionResult GetCaptcha()
        {
            return this.Captcha();
        }
    }
}
