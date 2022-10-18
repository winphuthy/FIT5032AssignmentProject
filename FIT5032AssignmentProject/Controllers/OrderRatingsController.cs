using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032AssignmentProject.Models;

namespace FIT5032AssignmentProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class OrderRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderRatings
        public ActionResult Index()
        {
            var orderRatings = db.OrderRatings.Include(o => o.Order);
            return View(orderRatings.ToList());
        }

        // GET: OrderRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRating orderRating = db.OrderRatings.Include(e=>e.Order).SingleOrDefault();
            if (orderRating == null)
            {
                return HttpNotFound();
            }
            return View(orderRating);
        }

        // GET: OrderRatings/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id");
            return View();
        }

        // POST: OrderRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RatingTime,Content,OrderId")] OrderRating orderRating)
        {
            if (ModelState.IsValid)
            {
                db.OrderRatings.Add(orderRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", orderRating.OrderId);
            return View(orderRating);
        }

        // GET: OrderRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRating orderRating = db.OrderRatings.Find(id);
            if (orderRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", orderRating.OrderId);
            return View(orderRating);
        }

        // POST: OrderRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RatingTime,Content,OrderId")] OrderRating orderRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", orderRating.OrderId);
            return View(orderRating);
        }

        // GET: OrderRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRating orderRating = db.OrderRatings.Find(id);
            if (orderRating == null)
            {
                return HttpNotFound();
            }
            return View(orderRating);
        }

        // POST: OrderRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRating orderRating = db.OrderRatings.Find(id);
            db.OrderRatings.Remove(orderRating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
