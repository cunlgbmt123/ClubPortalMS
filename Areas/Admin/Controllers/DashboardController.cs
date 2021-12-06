using ClubPortalMS.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "ADMIN, MOD")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}