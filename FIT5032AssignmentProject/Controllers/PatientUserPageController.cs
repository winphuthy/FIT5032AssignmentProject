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

            var Bookings = db.Orders.Include(o => o.Patient).Include(o => o.Service).Where(b => b.Patient.userId == userId).ToList();

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
    }
}