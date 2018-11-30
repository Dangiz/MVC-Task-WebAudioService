
using System.Web.Mvc;

namespace WebAudioService.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return new RedirectResult("Audio/");
        }
    }
}