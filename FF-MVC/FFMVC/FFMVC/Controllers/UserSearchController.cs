using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFMVC.Controllers
{
    public class UserSearchController : Controller
    {
        // GET: UserSearch
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserSearch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserSearch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSearch/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("UserSearch");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserSearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserSearch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("UserSearch");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserSearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserSearch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("UserSearch");
            }
            catch
            {
                return View();
            }
        }
    }
}
