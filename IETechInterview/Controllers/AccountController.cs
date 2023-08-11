//using AspNetCore;
using IETechInterview.Models;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
////using Microsoft.CodeAnalysis.CSharp.Syntax;
////using Microsoft.EntityFrameworkCore;

namespace IETechInterview.Controllers
{
        public class AccountController : Controller
        {
            private readonly AppDbContext _signInManager;

            public AccountController(AppDbContext signInManager)
            {
                _signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //if (ModelState.IsValid)
            //{
               
            //    //var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

            //    if (result.Succeeded)
            //    {
                    
            //        return RedirectToAction("Index", "Home");
            //    }

            //    ModelState.AddModelError("", "Invalid login attempt.");
            //}

           
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(LoginViewModel reg)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _signInManager.Users.Add(reg);
                    _signInManager.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allUsers = _signInManager.Users.ToList();
            if (allUsers == null)
            {
                return NotFound("No user in the Database");
            }
            return View(allUsers);
        }
        // GET: User/Edit/
        public IActionResult Edit(int id)
        {
            var user = _signInManager.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LoginViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _signInManager.Update(user);
                _signInManager.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/
        public IActionResult Delete(int id)
        {
            var user = _signInManager.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _signInManager.Users.Find(id);
            _signInManager.Users.Remove(user);
            _signInManager.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //// GET: User/DetailPage/5
        [HttpGet, ActionName("Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _signInManager.Users
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        
    }
}
