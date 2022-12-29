using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace KampusLearn.ViewComponents
{
    public class CourseDetailViewComponent:ViewComponent
    {
        private readonly IConfiguration config;
        private readonly ICourseRepository repo;

        public CourseDetailViewComponent(IConfiguration config,ICourseRepository repo)
        {
            this.config = config;
            this.repo = repo;
        }
       public async Task<IViewComponentResult> InvokeAsync( int courseId)
        {
                 

            return View(repo.GetCourseById(courseId));
        }
    }
}
