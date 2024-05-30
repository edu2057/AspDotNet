using Microsoft.AspNetCore.Mvc;
using WebApp2ByShikshya.Controllers.Repository;
using WebApp2ByShikshya.Models;

namespace WebApp2ByShikshya.Controllers
{
    public class StudentController : Controller
    {
        // Dependecy Injection
        private readonly IRepository<Student> _studentRepo = null;
        public StudentController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            // Retrive the data from DB before viewing the page
            List<Student>? stds = _studentRepo.GetAllRecords();
            return View(stds);
        }
    }
}
