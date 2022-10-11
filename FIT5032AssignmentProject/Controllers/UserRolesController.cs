using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032AssignmentProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FIT5032AssignmentProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager;

        public UserRolesController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: UserRoles
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return HttpNotFound();
            }

            var item = db.Roles.ToList();
            return View(item);
        }

        // GET: UserRoles/CreateRoles
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: UserRoles/CreateRoles
        [HttpPost]
        public ActionResult CreateRole(string RoleName)
        {
            try
            {
                db.Roles.Add(new IdentityRole()
                {
                    Name = RoleName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoles/ManageUserRole
        public ActionResult ManageUserRole()
        {
            return View();
        }

        // GET: UserRoles/EditRole
        public ActionResult EditRole(string roleName)
        {
            var role = db.Roles.FirstOrDefault(r => r.Name == roleName);
            return View(role);
        }

        // POST UserRoles/EditRole
        [HttpPost]
        public ActionResult EditRole(IdentityRole role)
        {
            try
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditRole");
            }
            catch
            {
                return View(role);
            }
        }

        public ActionResult Delete(string rolename)
        {
            var role = db.Roles.FirstOrDefault(r => r.Name == rolename);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserRoles/AddUserRole
        public ActionResult AddUserRole()
        {
            ViewBag.UserRole = db.Roles.ToList().Select(r => new SelectListItem {Value = r.Name, Text = r.Name})
                .ToList();
            ViewBag.UserList = db.Users.ToList().Select(u => new SelectListItem {Value = u.Email, Text = u.Email})
                .ToList();

            return View();
        }

        // POST UserRoles/AddUserRole
        [HttpPost]
        public ActionResult AddUserRole(string email, string role)
        {
            try
            {
                var user = userManager.FindByEmail(email);
                userManager.AddToRole(user.Id, role);
                /*ViewBag.UserList = db.Users.ToList().Select(u => new SelectListItem {Value = u.Email, Text = u.Email}).ToList();
                ViewBag.UserRole = db.Roles.ToList().Select(r => new SelectListItem {Value = r.Name, Text = r.Name})
                    .ToList();*/
                return RedirectToAction("AddUserRole");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: UserRoles/SearchUser
        public ActionResult SearchUser()
        {
            ViewBag.UserList = db.Users.ToList().Select(u => new SelectListItem {Value = u.Email, Text = u.Email})
                .ToList();
            return View();
        }

        // POST: UserRoles/SearchUser
        [HttpPost]
        public ActionResult SearchUser(string email)
        {
            try
            {
                ViewBag.UserList = db.Users.Select(u => new SelectListItem {Value = u.Email, Text = u.Email}).ToList();
                var user = userManager.FindByEmail(email);
                ViewBag.UserRoleList = userManager.GetRoles(user.Id);
                ViewBag.Email = email;
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            return View();
        }

        public ActionResult DeleteUserRole(string email, string role)
        {
            var user = userManager.FindByEmail(email);
            if (userManager.IsInRole(user.Id, role))
            {
                userManager.RemoveFromRole(user.Id, role);
            }

            return RedirectToAction("SearchUser");
        }
    }
}