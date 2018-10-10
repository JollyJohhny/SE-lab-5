using lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    public class DashboardController : Controller
    {
        public List<DateTime> BirthDays()
        {

            List<DateTime> daterange = new List<DateTime>();
            for (int i = 1; i < 11; i++)
            {
                DateTime t = DateTime.Now;
                daterange.Add(t.AddDays(i).Date);



            }
            DateTime today = DateTime.Now;
            daterange.Add(today.Date);
            return daterange;

        }

        public List<DateTime> LastSevenDays()
        {

            List<DateTime> daterange = new List<DateTime>();
            for (int i = -6; i < 0; i++)
            {
                DateTime t = DateTime.Now;
                daterange.Add(t.AddDays(i).Date);


            }
            DateTime today = DateTime.Now;
            daterange.Add(today.Date);

            return daterange;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            List<DateTime> birthdaydays = BirthDays();
            List<DateTime> lastSevenDays = LastSevenDays();

            List<PersonViewModel> birthdayBoys = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var persons = db.People;

            foreach (var a in persons)
            {
                foreach (DateTime j in birthdaydays)
                {
                    if (j.Day == Convert.ToDateTime(a.DateOfBirth).Day && j.Month == Convert.ToDateTime(a.DateOfBirth).Month)
                    {
                        PersonViewModel p = new PersonViewModel()
                        {

                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            PersonId = a.PersonId,
                            EmailId = a.EmailId,
                            ImagePath = a.ImagePath,


                        };
                        birthdayBoys.Add(p);
                    }
                }
            }

            List<PersonViewModel> updatedPerson = new List<PersonViewModel>();


            foreach (var b in persons)
            {
                foreach (DateTime j in lastSevenDays)
                {
                    if (j.Day == Convert.ToDateTime(b.UpdateOn).Day && j.Month == Convert.ToDateTime(b.UpdateOn).Month)
                    {
                        PersonViewModel p = new PersonViewModel
                        {

                            FirstName = b.FirstName,
                            MiddleName = b.MiddleName,
                            LastName = b.LastName,

                            EmailId = b.EmailId,

                        };
                        updatedPerson.Add(p);
                    }
                }
            }





            
            PhoneBookDbEntities ent = new PhoneBookDbEntities();
            var v = ent.People.ToString();
            int i = 0;
            DashboardViewModel d = new DashboardViewModel();
            
            foreach(var a in v)
            {
                i++;
            }
            d.NumberOfPersons = i;
            d.PersonsHavingBday = birthdayBoys;
            d.PersonsHavingBday = updatedPerson;

            return View(d);
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities ent = new PhoneBookDbEntities();

            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(DashboardViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
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
