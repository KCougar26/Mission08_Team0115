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
    // Implement Update and Delete similarly...
}