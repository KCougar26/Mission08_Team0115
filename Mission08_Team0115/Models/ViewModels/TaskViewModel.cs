using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission08_Team0115.Models.ViewModels
{
    public class TaskViewModel
    {
        public TaskModel Task { get; set; } = new TaskModel();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
