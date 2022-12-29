using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace KampusLearn.Controllers
{
    public class CoursesController : Controller
    {
       
        private readonly IConfiguration config;
        private readonly ICourseRepository repo;
        string conString;
        public CoursesController(IConfiguration config,ICourseRepository repo)
        {
            this.config = config;
        this.    repo = repo;
            conString = config.GetConnectionString("KampusLearn");
        }
     
        public IActionResult  Index()
        {

          

            
           return View(repo.GetAllCourses());
        }


        public IActionResult GetCourses()
        {
           

            return View(repo.GetAllCourses());
        }

        public IActionResult GetCourse(int courseId)
        {

            return View(repo.GetCourseById(courseId));
        }
      

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
          
            repo.AddNewCourse(course);
            return RedirectToAction("Index");
        }
             
        public IActionResult UpdateCourse(int courseId)
        {

             return View(repo.GetCourseById(courseId));
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            repo.UpdateCourse(course);
            return RedirectToAction("Index"); ;
         }

        public IActionResult DeleteCourse(int courseId)
        {
            return View(repo.GetCourseById(courseId));
                    }

    public IActionResult Yes(int courseId)
        {
         repo.DeleteCourse(courseId);
            return RedirectToAction("Index");
        }
    
    }

    
}
