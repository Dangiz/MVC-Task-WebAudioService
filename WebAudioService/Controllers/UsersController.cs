
using System.Linq;
using System.Web.Mvc;
using WebAudioService.DataAccessContracts;
using WebAudioService.Entities;
using WebAudioService.Models;
using WebAudioService.ListDataAccess;
using WebAudioService.Services;

namespace WebAudioService.Controllers
{
    public class UsersController : Controller
    {

        IUserDao users=new CollectionUserRepo();
        IAudioDao audios = new CollectionAudioRepo();

        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction($"Details/{ users.GetUserByName(HttpContext.User.Identity.Name).Id}");
        }

        [Filter.Admin]
        [Authorize]
        public ActionResult All()
        {
            return View("UserList", users.SelectAll());
        }

        public ActionResult Details(int id)
        {
            var userid = users.GetUserByName(HttpContext.User.Identity.Name).Id;
            if (users.HasUser(id) && (userid==id || UserRoleService.UserHasRole(userid,"Admin")))
            {
                var username = users.GetUserById(id).Name;
                var userAudios = audios.GetAudiosByUserId(id).Select(audio => new AudioWithUsername(username,id, audio.Id, audio.ContentType));
                return View(new UserWithAudios() { Name = username, Audios = userAudios });
            }
            else return new HttpNotFoundResult();
        }

        [Filter.Admin]
        public ActionResult Delete(int id)
        {
            if (users.HasUser(id) && users.GetUserByName(HttpContext.User.Identity.Name).Id!=id)
                return View(users.GetUserById(id));
            else return RedirectToAction("All");
        }

        [HttpPost]
        [Filter.Admin]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (users.HasUser(id) && users.GetUserByName(HttpContext.User.Identity.Name).Id != id)
                {
                    users.DeleteById(id);
                }

                return RedirectToAction("All");
            }
            catch
            {
                return View();
            }
        }
    }
}
