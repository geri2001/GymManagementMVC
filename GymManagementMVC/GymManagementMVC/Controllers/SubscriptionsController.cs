using GymManagementMVC.Data;
using GymManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers
{
	public class SubscriptionsController : Controller
	{
		private readonly ApplicationDbContext _context;
        public SubscriptionsController(ApplicationDbContext context)
        {
			_context = context;
        }
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Subscription subscription)
		{
			if(ModelState.IsValid)
			{
				_context.Subscriptions.Add(subscription);
				_context.SaveChanges();

				return RedirectToAction(nameof(Index));

			}
			return View(subscription);
		}
		public IActionResult Details(int id)
		{
			var sub = _context.Subscriptions.FirstOrDefault(s => s.Id == id);

			return View(sub);
		}
		public IActionResult Edit(int id)
		{
			var sub = _context.Subscriptions.FirstOrDefault(s => s.Id == id);

			if (sub == null)
				return NotFound();

			return View(sub);
		}

		[HttpPost]
		public IActionResult Edit(int id, Subscription subscription)
		{
			if (id != subscription.Id)
				return NotFound();

			if(ModelState.IsValid)
			{
				var subInDb = _context.Subscriptions.Find(id);

				if (subInDb == null)
					return NotFound();

				subInDb.Code = subscription.Code;
				subInDb.Description = subscription.Description;
				subInDb.NumberOfMonths = subscription.NumberOfMonths;
				subInDb.WeekFrequency = subscription.WeekFrequency;
				subInDb.TotalNumberOfSessions = subscription.TotalNumberOfSessions;
				subInDb.TotalPrice = subscription.TotalPrice;

				_context.SaveChanges();

				return RedirectToAction(nameof(Index));
			}

			return View(subscription);
		}
	}
}
