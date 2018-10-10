using lab5.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();

        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var con = db.Contacts;
            List<ContactViewModel> li = new List<ContactViewModel>();
            foreach(var i in con)
            {
                if(i.PersonId == id)
                {
                    ContactViewModel n = new ContactViewModel();
                    n.ContactId = i.ContactId;
                    n.ContactNumber = i.ContactNumber;
                    n.Type = i.Type;
                    n.PersonId = i.PersonId;
                    li.Add(n);
                }
            }
            return View(li);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id,ContactViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Contact c = new Contact();
                c.ContactNumber = collection.ContactNumber;
                c.Type = collection.Type;
                c.PersonId = id;
                db.Contacts.Add(c);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                var i = db.Contacts.Where(y => y.ContactId == id).First();
                i.ContactNumber = collection.ContactNumber;
                i.Type = collection.Type;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();

            var contacts = db.Contacts.Where(x => x.ContactId == id);

            db.Entry(contacts).State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
