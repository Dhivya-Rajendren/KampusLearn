using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace KampusLearn.ViewComponents
{
    public class CourseDetailViewComponent:ViewComponent
    {
        private readonly IConfiguration config;

        public CourseDetailViewComponent(IConfiguration config)
        {
            this.config = config;
        }
       public async Task<IViewComponentResult> InvokeAsync( int courseId)
        {
            
            DBHelper repo = new DBHelper(config.GetConnectionString("KampusLearn"));

            return View(repo.GetCourseById(courseId));
        }
    }
}
