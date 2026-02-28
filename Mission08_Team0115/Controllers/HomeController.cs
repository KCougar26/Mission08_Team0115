using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0115.Models;
using Mission08_Team0115.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Mission08_Team0115.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repo;
        private readonly TaskContext _context;

        public HomeController(ITaskRepository temp, TaskContext context)
        {
            _repo = temp;
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.Completed)
                .ToList();
            return View(tasks);
        }

        // Show list of tasks (grouping / filtering can be done in the view)
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks;
            return View(tasks);
        }

        // GET: Show Add (or Edit) form
        [HttpGet]
        public IActionResult AddTask(int? id)
        {
            var vm = new TaskViewModel();

            // populate categories for the dropdown
            vm.Categories = _context.Categories
                .Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString() })
                .ToList();

            if (id != null)
            {
                var existing = _repo.Tasks.FirstOrDefault(t => t.TaskId == id.Value);
                if (existing != null)
                {
                    vm.Task = existing;
                }
            }

            return View(vm);
        }

        // POST: Add or Update task
        [HttpPost]
        public IActionResult AddTask(TaskViewModel tvm)
        {
            if (!ModelState.IsValid)
            {
                // repopulate categories if validation fails
                tvm.Categories = _context.Categories
                    .Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString() })
                    .ToList();
                return View(tvm);
            }

            if (tvm.Task.TaskId == 0)
            {
                _repo.AddTask(tvm.Task);
            }
            else
            {
                _repo.UpdateTask(tvm.Task);
            }

            return RedirectToAction("Quadrants");
        }

        // Delete a task by id
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _repo.DeleteTask(task);
            }

            return RedirectToAction("Quadrants");
        }
        
    }
}

