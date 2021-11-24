using ClubPortalMS.Areas.Customer.DAO;
using System.Web.Mvc;
using ClubPortalMS.Models;



namespace ClubPortalMS.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer/Home
        public ActionResult Index()
        {
            var ListDAO = new ListDAO();
            ViewBag.ListNews = ListDAO.ListNews(5);
            ViewBag.ListHD = ListDAO.listHD(5);
            ViewBag.Slides = new SlideDao().ListAll();
            ViewBag.ListAlbums = new ListDAO().ListAlbums(9);
            return View();
        } 
    }
}