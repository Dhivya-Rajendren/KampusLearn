using System.Collections.Generic;

namespace KampusLearn.Models
{
    public class CourseRepository:ICourseRepository
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course(){CourseId = 1, CourseName = "Basics of ASP .Net Core", Technology = ".Net Core", Duration = 20},
            new Course(){CourseId = 2, CourseName ="Certified Full Stack Development",Technology="Full Stack Development", Duration=100}
        };
        // Working on CRUD

        //Reading the data
       

        public Course GetCourseById(int courseId)
        {
            Course course = courses.Find(x => x.CourseId == courseId);
            return course;
        }

        // Creating the data
        public int AddNewCourse(Course course)
        {
            int count = courses.Count;
            courses.Add(course);
            int newCount = courses.Count;
            return newCount - count;

        }
                public int UpdateCourse(Course course)
        {
            Course newCourse = courses.Find(x => x.CourseId == course.CourseId);
            courses.Remove(newCourse);
            newCourse.CourseName = course.CourseName;
            newCourse.Technology = course.Technology;
            newCourse.Duration = course.Duration;
            courses.Add(newCourse);
            return 1;
        }

        //Delete in CRUD
        public int DeleteCourse(int courseId)
        {
            Course newCourse = courses.Find(x => x.CourseId == courseId);
            courses.Remove(newCourse);
            return 1;
        }

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public List<Trainer> GetAllTrainers()
        {
            throw new System.NotImplementedException();
        }

        public Trainer GetTrainerById(int trainerId)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteTrainer(int trainerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
