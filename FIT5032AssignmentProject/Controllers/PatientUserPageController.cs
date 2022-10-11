﻿using System.Data.Entity;
using FIT5032AssignmentProject.Models;
using System.Linq;
using System.Web.Mvc;
using System.Net;

namespace FIT5032AssignmentProject.Controllers
{
    // [Authorize(Roles = "Patient")]
    public class PatientUserPageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Therapist);
            return View(services.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Service service = db.Services.Include(e => e.Therapist).SingleOrDefault();
            ViewBag.Id = service.Id;

            if (service == null)
            {
                return HttpNotFound();
            }

            return View(service);
        }

        public JsonResult GetServices()
        {
            var positions = db.Services.ToList();

            return new JsonResult {Data = positions, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}