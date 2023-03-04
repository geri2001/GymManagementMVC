using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers
{
	public class SubscriptionsController : Controller
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
