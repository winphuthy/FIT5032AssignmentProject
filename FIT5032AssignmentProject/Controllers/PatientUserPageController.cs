using System.Collections.Generic;
using System.Data.Entity;
using FIT5032AssignmentProject.Models;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity;

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

            Service service = db.Services.Include(s => s.Therapist).SingleOrDefault(s => s.Id == id);

            if (service == null)
            {
                return HttpNotFound();
            }

            return View(service);
        }

        public ActionResult UserOrder()
        {
            var userId = User.Identity.GetUserId();

            var Bookings = db.Orders.Where(b => b.Patient.userId == userId).ToList();
            return View(Bookings);
        }

        public JsonResult GetServices()
        {
            var positions = db.Services.ToList();

            return new JsonResult {Data = positions, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult GetBooking()
        {
            string userId = User.Identity.GetUserId();

            var Bookings = db.Orders.Include(o => o.Patient).Include(o => o.Service)
                .Where(b => b.Patient.userId == userId).ToList();

            return new JsonResult {Data = Bookings, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Include(e => e.Patient).Include(e => e.Service).SingleOrDefault(o => o.Id == id);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }


        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var service = db.Services.Where(s => s.Id == id).ToList();

            if (service == null)
            {
                return HttpNotFound();
            }


            string userId = User.Identity.GetUserId();
            var patient = db.Patients.Where(p => p.userId == userId).ToList();


            ViewBag.PatientId = new SelectList(patient, "PatientID", "FirstName");
            ViewBag.ServiceId = new SelectList(service, "Id", "Name");
            /*ViewBag.PatientId = new SelectList(db.Patients, "PatientID", "FirstName");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "Id,OrderTime,ServiceId,PatientId,Comment")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "PatientID", "FirstName", order.PatientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", order.ServiceId);
            return View(order);
        }

        public ActionResult MyOrder()
        {
            string userId = User.Identity.GetUserId();
            var orders = db.Orders.Include(o => o.Patient).Include(o => o.Service).Where(o => o.Patient.userId == userId);
            return View(orders.ToList());

        }
    }
}