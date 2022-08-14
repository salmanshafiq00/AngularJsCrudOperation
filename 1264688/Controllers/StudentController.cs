using _1264688.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1264688.Controllers
{
    public class StudentController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public JsonResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var students = db.Students.Join(db.Departments,
                s => s.DepartmentId,
                d => d.DepartmentId,
                (s, d) => new { s.Id, s.Name, s.DOB, s.IsRegular, d.DepartmentName, s.ImagePath });
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var student = db.Students.Find(Id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDept()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var dptList = db.Departments.ToList();
            return Json(dptList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Json(null);
        }


        [HttpPost]
        public JsonResult Edit(Student student)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(null);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var student = db.Students.Find(Id);
            db.Students.Remove(student);
            db.SaveChanges();
            return Json(null);
        }
    }
}