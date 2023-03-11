using GymManagementMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	public SubscriptionsController(ApplicationDbContext context)
	{
		_context = context;
	}
	public IActionResult GetAll()
	{
		var subs = _context.Subscriptions.Where(s => s.IsDeleted == false).ToList();

		return Ok(subs);
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var sub = _context.Subscriptions.Find(id);

		if (sub == null)
			return NotFound();

		sub.IsDeleted = true;

		_context.SaveChanges();

		return NoContent();
	}
}
