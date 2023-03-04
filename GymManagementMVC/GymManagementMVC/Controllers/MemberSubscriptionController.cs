using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers
{
    public class MemberSubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
