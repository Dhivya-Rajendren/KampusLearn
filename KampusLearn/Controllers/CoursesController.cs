using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace KampusLearn.Controllers
{
    public class CoursesController : Controller
    {
        CourseRepository repo;
        DBHelper dbHelper;
        private readonly IConfiguration config;
        string conString;
        public CoursesController(IConfiguration config)
        {
            this.config = config;
            conString = config.GetConnectionString("KampusLearn");
        }
     
        public IActionResult  Index()
        {

            dbHelper = new DBHelper(conString);

            
           return View(dbHelper.GetAllCourses());
        }


        public IActionResult GetCourses()
        {
            repo = new CourseRepository();

            return View(repo.GetAllCourses());
        }

        public IActionResult GetCourse(int courseId)
        {
            dbHelper = new DBHelper(conString);

            return View(dbHelper.GetCourseById(courseId));
        }
      

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            dbHelper = new DBHelper(conString);
            dbHelper.AddNewCourse(course);
            return RedirectToAction("Index");
        }
             
        public IActionResult UpdateCourse(int courseId)
        {

            repo = new CourseRepository();
             return View(repo.GetCourseById(courseId));
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            repo = new CourseRepository();
            repo.UpdateCourse(course);
            return RedirectToAction("Index"); ;
         }

        public IActionResult DeleteCourse(int courseId)
        {
            dbHelper = new DBHelper(conString);
            return View(dbHelper.GetCourseById(courseId));
                    }

    public IActionResult Yes(int courseId)
        {
            dbHelper = new DBHelper(conString);
         dbHelper.DeleteCourse(courseId);
            return RedirectToAction("Index");
        }
    
    }

    
}
