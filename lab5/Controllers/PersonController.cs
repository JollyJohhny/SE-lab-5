using lab5.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        // GET: PersonViewModel
        public ActionResult Index()
        {
            //return Redirect("~/Contact/Index");
            List<PersonViewModel> db = new List<PersonViewModel>();
            PhoneBookDbEntities ent = new PhoneBookDbEntities();
            var dblist = ent.Person.ToList();
            foreach(var i in dblist)
            {
                if(i.AddedBy == User.Identity.GetUserId())
                {
                    PersonViewModel person = new PersonViewModel();
                    person.PersonId = i.PersonId;
                    person.FirstName = i.FirstName;
                    person.LastName = i.LastName;
                    person.MiddleName = i.MiddleName;
                    person.DateOfBirth = Convert.ToDateTime(i.DateOfBirth);
                    person.AddedBy = User.Identity.GetUserId();
                    person.AddedOn = Convert.ToDateTime(i.AddedOn);
                    person.HomeAddress = i.HomeAddress;
                    person.HomeCity = i.HomeCity;
                    person.FaceBookAccountId = i.FaceBookAccountId;
                    person.LinkedInId = i.LinkedInId;
                    person.UpdateOn = Convert.ToDateTime(i.UpdateOn);
                    person.ImagePath = i.ImagePath;
                    person.TwitterId = i.TwitterId;
                    person.EmailId = i.EmailId;
                    db.Add(person);
                }
                
            }
            

            return View(db);
        }


       

        // GET: PersonViewModel/Details/1
        public ActionResult Details(int id)
        {
            
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<PersonViewModel> li = new List<PersonViewModel>();
            var plist = db.Person.ToList();
            foreach(var i in plist)
            {
              if(i.PersonId == id)
                {
                    
                    PersonViewModel person = new PersonViewModel();
                    person.PersonId = i.PersonId;
                    person.FirstName = i.FirstName;
                    person.LastName = i.LastName;
                    person.MiddleName = i.MiddleName;
                    person.DateOfBirth = Convert.ToDateTime(i.DateOfBirth);
                    person.AddedBy = i.AddedBy;
                    person.AddedOn = Convert.ToDateTime(i.AddedOn);
                    person.HomeAddress = i.HomeAddress;
                    person.HomeCity = i.HomeCity;
                    person.FaceBookAccountId = i.FaceBookAccountId;
                    person.LinkedInId = i.LinkedInId;
                    person.UpdateOn = Convert.ToDateTime(i.UpdateOn);
                    person.ImagePath = i.ImagePath;
                    person.TwitterId = i.TwitterId;
                    person.EmailId = i.EmailId;
                    li.Add(person);
                }
                
            }
            
            return View(li);

        }

        // GET: PersonViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonViewModel/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                Person p = new Person();
                p.FirstName = collection.FirstName;
                p.MiddleName = collection.MiddleName;
                p.LastName = collection.LastName;
                p.DateOfBirth = collection.DateOfBirth;
                p.AddedBy = User.Identity.GetUserId();
                p.AddedOn = DateTime.Now;
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                //p.UpdateOn = collection.UpdateOn;
                p.ImagePath = collection.ImagePath;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;
                db.Person.Add(p);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                
                var i = db.Person.Where(y=>y.PersonId == id).First();
               
                i.FirstName = collection.FirstName;
                i.LastName = collection.LastName;
                i.MiddleName = collection.MiddleName;
                i.DateOfBirth = collection.DateOfBirth;
                //i.AddedBy = i.AddedBy;
                //i.AddedOn = Convert.ToDateTime(i.AddedOn);
                i.HomeAddress = i.HomeAddress;
                i.HomeCity = i.HomeCity;
                i.FaceBookAccountId = i.FaceBookAccountId;
                i.LinkedInId = i.LinkedInId;
                i.UpdateOn = DateTime.Now;
                i.ImagePath = i.ImagePath;
                i.TwitterId = i.TwitterId;
                i.EmailId = i.EmailId;
                db.SaveChanges();

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            
            
            return View();
        }

        // POST: PersonViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                var contacts = db.Contacts.Where(x => x.PersonId == id).ToList();
                foreach (var i in contacts)
                {
                    Contact c = new Contact()
                    {
                        ContactId = i.ContactId
                    };
                    db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                }

                db.SaveChanges();

                //var person = db.Person.Where(x => x.PersonId == id).First();
                Person p = new Person()
                {
                    PersonId = id
                };
                db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Content(p.PersonId.ToString());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
