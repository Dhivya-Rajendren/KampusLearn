using System.Collections.Generic;

namespace KampusLearn.Models
{
    public interface ICourseRepository
    {

        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);

        int AddNewCourse(Course course);

        int UpdateCourse(Course course);

        int DeleteCourse(int courseId);

        List<Trainer> GetAllTrainers();
        Trainer GetTrainerById(int trainerId);
        int DeleteTrainer(int trainerId);


    }
}
