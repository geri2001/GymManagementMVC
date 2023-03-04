using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
