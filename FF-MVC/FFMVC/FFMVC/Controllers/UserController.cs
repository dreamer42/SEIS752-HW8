using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FFMVC.Models;

namespace FFMVC.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.FFUsers.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }

            return View(fFUser);

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            FFUser fFUser = db.FFUsers.Find(id);
//            FFUserDetail fFuserDetail = new FFUserDetail();
//            if (fFUser == null)
//            {
//                return HttpNotFound();
//            }

//            fFuserDetail.user = fFUser;
//            fFuserDetail.friends = db.FFUsers.ToList();  // TODO: filter down based on distances

//            //FFUserDetail

//            return View(fFuserDetail);

        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,lat,lon,ImageUrl")] FFUser fFUser)
        {
            if (ModelState.IsValid)
            {
                db.FFUsers.Add(fFUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fFUser);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }
            return View(fFUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Username,lat,lon,ImageUrl")] FFUser fFUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fFUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fFUser);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }
            return View(fFUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FFUser fFUser = db.FFUsers.Find(id);
            db.FFUsers.Remove(fFUser);
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

        public double distanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            var rlat1 = Math.PI * lat1 / 180;
            var rlat2 = Math.PI * lat2 / 180;
            var rlon1 = Math.PI * lon1 / 180;
            var rlon2 = Math.PI * lon2 / 180;
            var theta = lon1 - lon2;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = dist * 0.8684;
            return dist;
        }
    }
}
