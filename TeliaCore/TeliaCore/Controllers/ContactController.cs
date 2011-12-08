using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeliaCore.Models;
using TeliaCore.Services.Interfaces;

namespace TeliaCore.Controllers
{
    public class ContactController : Controller
    {
          public Model1Container _db { get; set; }
        public ContactController()
        {
            _db = new Model1Container();
        
        }

        //
        // GET: /Contact/

        public ActionResult Index()
        {
return View();
        }


        public ActionResult Create(Contact contact)
        {
            contact.LastOnline = DateTime.Now;
            contact.CreateDate = DateTime.Now;

            _db.Contacts.Add(contact);
            _db.SaveChanges();

            return View("List");
        }

        public ActionResult List()
        {
            return View(_db.Contacts.ToList());
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var contact = _db.Contacts.Find(id);

            _db.Entry(contact).State = EntityState.Deleted;
            _db.SaveChanges();
            return View();
        }


    }
}
