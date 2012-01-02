using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models.Auth;

namespace HRManagement.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty("bb"))
            {
                filterContext.HttpContext.User = new CustomPrincipal(new CustomIdentity("bb"));
            }
            
            base.OnAuthorization(filterContext);
        }

    }
}
