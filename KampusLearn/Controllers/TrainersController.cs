using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KampusLearn.Controllers
{
    public class TrainersController : Controller
    {
        private readonly IConfiguration config;
       private ICourseRepository repo;

        public TrainersController(IConfiguration config,ICourseRepository repo)
        {
            this.config = config;
            this.repo = repo;
        }
      public IActionResult Index()
        {
            return View(repo.GetAllTrainers());
        }

        public IActionResult GetTrainer(int trainerId)
        {

            return View(repo.GetTrainerById(trainerId));
        }

        public IActionResult DeleteTrainer(int trainerId)
        {

            return View(repo.GetTrainerById(trainerId));
        }
    }
}
