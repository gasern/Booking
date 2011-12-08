using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;

namespace TeliaCore.Controllers
{ 
    public class MealController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Meal/

        public JsonResult GetMenu()
        {
            var menuList = db.RefreshmentItems.ToList();

            return Json(new
            {
                success = true,
                menulist = menuList,
            }, JsonRequestBehavior.AllowGet);
        }

        public ViewResult Index()
        {
            return View(db.RefreshmentItems.ToList());
        }

        //
        // GET: /Meal/Details/5

        public ViewResult Details(int id)
        {
            RefreshmentItem refreshment = db.RefreshmentItems.Find(id);
            return View(refreshment);
        }

        //
        // GET: /Meal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Meal/Create

        [HttpPost]
        public ActionResult Create(RefreshmentItem refreshment)
        {
            if (ModelState.IsValid)
            {
                db.RefreshmentItems.Add(refreshment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(refreshment);
        }
        
        //
        // GET: /Meal/Edit/5
 
        public ActionResult Edit(int id)
        {
            RefreshmentItem refreshment = db.RefreshmentItems.Find(id);
            return View(refreshment);
        }

        //
        // POST: /Meal/Edit/5

        [HttpPost]
        public ActionResult Edit(RefreshmentItem refreshment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refreshment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refreshment);
        }

        //
        // GET: /Meal/Delete/5
 
        public ActionResult Delete(int id)
        {
            RefreshmentItem refreshment = db.RefreshmentItems.Find(id);
            return View(refreshment);
        }

        //
        // POST: /Meal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RefreshmentItem refreshment = db.RefreshmentItems.Find(id);
            db.RefreshmentItems.Remove(refreshment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}