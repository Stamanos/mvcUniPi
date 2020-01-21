using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        private UniversityEntities db = new UniversityEntities();

        // GET: Students
        public ActionResult Index()
        {
            IQueryable<Student> list = db.Student;

            string lastname = Request.QueryString["lastname"];
            if (lastname != null && lastname != "")
            {
                list = db.Student.Where(m => m.LastName.StartsWith(lastname));
            }

            if (Request.QueryString["dateFrom"] != null && Request.QueryString["dateFrom"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime datefrom);
                list = db.Student.Where(m => m.EnrollmentDate >= datefrom);
            }

            if (Request.QueryString["dateTo"] != null && Request.QueryString["dateTo"] != "")
            {
                DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateto);
                list = db.Student.Where(m => m.EnrollmentDate <= dateto);
            }
           
            return View( list.ToList());
        }

        // GET: Students
        //public ActionResult Index2()
        //{
        //    Student stud = new Student();

        //    string lastname = Request.QueryString["lastname"];
        //    string date1 = Request.QueryString["dateFrom"];
        //    DateTime datefrom ;
        //    DateTime dateto ;

        //    if (Request.QueryString["dateFrom"] != null && Request.QueryString["dateFrom"] != "")
        //    {
        //        DateTime.TryParse(Request.QueryString["dateFrom"], out datefrom);
        //    }
        //    if (Request.QueryString["dateTo"] != null && Request.QueryString["dateTo"] != "")
        //    {
        //        DateTime.TryParse(Request.QueryString["dateTo"], out dateto);
        //    }

        //    List<Student> result = db.FN_sp_searchStudent(lastname, datefrom, dateto).ToList();
           

        //    return View(result);
        //}

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
