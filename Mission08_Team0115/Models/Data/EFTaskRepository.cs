using Microsoft.EntityFrameworkCore;
namespace Mission08_Team0115.Models;
public class EFTaskRepository : ITaskRepository
{
    private TaskContext _context;
    public EFTaskRepository(TaskContext temp)
    {
        _context = temp;
    }

    public List<TaskModel> Tasks => _context.Tasks.Include(x => x.Category).ToList();

    public void AddTask(TaskModel task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }
    public void UpdateTask(TaskModel task)
    {
        _context.Update(task);
        _context.SaveChanges();
    }
    public void DeleteTask(TaskModel task)
    {
        _context.Remove(task);
        _context.SaveChanges();
    }
}