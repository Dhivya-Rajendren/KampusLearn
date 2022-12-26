using KampusLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KampusLearn.Controllers
{
    public class TrainersController : Controller
    {
        private readonly IConfiguration config;
        DBHelper repo;

        public TrainersController(IConfiguration config)
        {
            this.config = config;
        }
      public IActionResult Index()
        {
            repo = new DBHelper(config.GetConnectionString("KampusLearn"));
            return View(repo.GetAllTrainers());
        }

        public IActionResult GetTrainer(int trainerId)
        {
            repo = new DBHelper(config.GetConnectionString("KampusLearn"));

            return View(repo.GetTrainerById(trainerId));
        }

        public IActionResult DeleteTrainer(int trainerId)
        {
            repo = new DBHelper(config.GetConnectionString("KampusLearn"));

            return View(repo.GetTrainerById(trainerId));
        }
    }
}
