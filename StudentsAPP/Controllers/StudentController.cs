using StudentAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentAPP.Controllers
{
    public class StudentController : Controller
    {
        public List<Student> Students { get; set; }
        public StudentController()
        {
            Students = new List<Student>()
            {
                new Student() {Id = 1, FirstName = "First1", LastName = "Last"},
                new Student() {Id = 2, FirstName = "Third1", LastName = "Fourth"}
            };
        }

        public ActionResult Index()
        {
            return View(Students);
        }

        public ActionResult Edit(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (Students.FirstOrDefault(s => s.Id == id) != null)
                {
                    Students.FirstOrDefault(s => s.Id == id).FirstName = student.LastName;
                    Students.FirstOrDefault(s => s.Id == id).LastName = student.LastName;
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student std)
        {
            if (std != null)
            {
                Students.Remove(std);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult Details(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Students.Add(std);
                }
                ViewBag.Count = Students.Count;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}