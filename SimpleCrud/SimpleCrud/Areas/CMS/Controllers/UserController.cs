using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;
using SimpleCrud.Repository.UserRepository;
using SimpleCrud.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.Areas.CMS.Controllers
{
    [Area("cms")]
    [Route("{cms}/user")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var user = _userRepository.GetAll();
            return View(user);
        }

        // GET: Users/Details/5
        [Route("details")]

        public IActionResult Details(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpGet]
        [Route("create")]

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,Number")] User user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepository<User>().Insert(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        [Route("edit/{id}")]

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {

            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("edit/{id}")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {

            var user = _userRepository.GetById(id);
            if (await TryUpdateModelAsync<User>(
                user,
                "",
                s => s.Name, s => s.Address, s => s.Number))
            {
                try
                {
                    _unitOfWork.GetRepository<User>().Update(user);
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        // GET: Users/Delete/5
        [Route("delete/{id}")]

        public IActionResult Delete(int id)
        {

            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Remove(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
