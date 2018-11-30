
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebAudioService.DataAccessContracts;
using WebAudioService.ListDataAccess;
using WebAudioService.Entities;
using System;
using System.Linq;
using WebAudioService.Models;
using WebAudioService.Services;

namespace WebAudioService.Controllers
{
    public class AudioController : Controller
    {
        IAudioDao audios=new CollectionAudioRepo();
        IUserDao users = new CollectionUserRepo();
        // GET: Audio

        private AudioWithUsername AudiuoToAudioWithUsername(Audio audio)
        {
            return new AudioWithUsername(users.GetUserById(audio.UserId).Name, audio.UserId, audio.Id, audio.ContentType);
        }



        [Authorize]
        public ActionResult Index()
        {
            var result = audios.SelectAll().Select(audio => AudiuoToAudioWithUsername(audio));
            return View(result);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            if (audios.HasAudio(id))
            {
                Audio audio = audios.GetAudioById(id);
                return File(audio.Data, audio.ContentType);
            }
            else return Content("Unkown error by loading");
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(HttpPostedFileBase upload)
        {
            try
            {
                if(upload==null)
                {
                    throw new Exception("File was not loaded");
                }

                using (BinaryReader reader = new BinaryReader(upload.InputStream))
                {
                    var data = reader.ReadBytes(upload.ContentLength);
                    var userId = users.GetUserByName(HttpContext.User.Identity.Name).Id;
                    audios.Insert(new Audio(userId,data, upload.FileName,upload.ContentType));
                }
                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                ViewBag.Message = exception.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (audios.HasAudio(id) || UserAudioService.UserHasAudio(HttpContext.User.Identity.Name,id) || UserRoleService.UserHasRole(HttpContext.User.Identity.Name,"Admin"))
            {
                return View(AudiuoToAudioWithUsername((audios.GetAudioById(id))));
            }
            else return RedirectToAction("Index");
        }

        // POST: Temp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (audios.HasAudio(id) || UserAudioService.UserHasAudio(HttpContext.User.Identity.Name, id) || UserRoleService.UserHasRole(HttpContext.User.Identity.Name, "Admin"))
                {
                    audios.DeleteById(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
