using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KampusLearn.Models
{
    public class DBHelper : ICourseRepository
    {
            IConfiguration configuration;
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        string connectionString = null;

        public DBHelper(IConfiguration configuration)
        {
            
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("KampusLearn"));
            con.Open();
        }
        public int AddNewCourse(Course course)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            com = new SqlCommand("insert into tbl_Course values('" + course.CourseName + "','" + course.Technology + "'," + course.Fees + "," + course.Duration + ",' ')", con);
            return com.ExecuteNonQuery();
        }

        public int DeleteCourse(int courseId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            com = new SqlCommand("Delete from tbl_course where courseId=" + courseId, con);
            return com.ExecuteNonQuery();
        }

        public int DeleteTrainer(int trainerId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            com = new SqlCommand("Delete from tbl_trainers where trainerId=" + trainerId, con);
            return com.ExecuteNonQuery();
        }

        public List<Course> GetAllCourses()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            com = new SqlCommand("Select * from tbl_Course", con);
            reader = com.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseId = reader.GetInt32(0);
                course.CourseName = reader.GetString(1);
                course.Technology = reader.GetString(2);
                course.Fees = reader.GetInt32(3);
                course.Duration = reader.GetInt32(4);
                course.CourseImg = reader.GetString(5);
                courses.Add(course);
            }
            reader.Close();
            con.Close();

            return courses;
        }



        public Course GetCourseById(int courseId)
        {
            Course course = GetAllCourses().Find(x => x.CourseId == courseId);
            reader.Close();

            return course;
        }

        public Trainer GetTrainerById(int trainerId)
        {
            Trainer trainer = GetAllTrainers().Find(t => t.TrainerId == trainerId);
            return trainer;
        }

        public int UpdateCourse(Course course)
        {
            throw new System.NotImplementedException();
        }


        public List<Trainer> GetAllTrainers()
        {
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                com = new SqlCommand("Select * from tbl_Trainers", con);
                reader = com.ExecuteReader();
                List<Trainer> trainers = new List<Trainer>();
                while (reader.Read())
                {
                    Trainer trainer = new Trainer();
                    trainer.TrainerId = reader.GetInt32(0);
                    trainer.TrainerName = reader.GetString(1);
                    trainer.Email = reader.GetString(2);
                    trainer.Contact = reader.GetInt64(3);
                    trainer.Skills = reader.GetString(4);
                    trainer.YearsOfExperience = reader.GetInt32(5);
                    trainers.Add(trainer);
                }
                return trainers;

            }
        }
    }
}
