using GymManagementMVC.Data;
using GymManagementMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public MembersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: MembersController
        public ActionResult Index()
        {
            var members = _context.Users.ToList();

            return View(members);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUser member)
        {

            if (ModelState.IsValid)
            {
                _context.Users.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
