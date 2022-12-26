namespace KampusLearn.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Technology { get; set; }

        public int Duration { get; set; }
        public int Fees { get; set; }

        public string CourseImg { get; set; }


    }
}
