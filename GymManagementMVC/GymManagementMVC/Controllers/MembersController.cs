using GymManagementMVC.Data;
using GymManagementMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
        //public actionresult index()
        //{
        //    var members = _context.users.tolist();

        //    return view(members);
        //}

        public ActionResult Index(string? name)
        {
            List<ApplicationUser> members;

            if (string.IsNullOrWhiteSpace(name))
                members = _context.Users
                    .Where(u => !u.IsDeleted)
                    .ToList();
            else
                members = _context.Users
                    .Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name) || s.Email.Contains(name))
                    .Where(u => !u.IsDeleted)
                    .ToList();
            
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


        // POST: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            var member = _context.Users.FirstOrDefault(x => x.Id == id);
            member.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
