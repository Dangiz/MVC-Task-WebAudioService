using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using WebAudioService.Entities;
using WebAudioService.ListDataAccess;
using WebAudioService.DataAccessContracts;
using WebAudioService.Services;

namespace WebAudioService.Filter
{
    public class Admin : FilterAttribute, IActionFilter
    {
        IUserRoleDao roles=new CollectionUserRoleRepo();
        IUserDao users = new CollectionUserRepo();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (!UserRoleService.UserHasRole(filterContext.HttpContext.User.Identity.Name,"Admin"))
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (!UserRoleService.UserHasRole(filterContext.HttpContext.User.Identity.Name, "Admin"))
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}