public interface ITaskRepository
{
    List<TaskModel> Tasks { get; }
    void AddTask(TaskModel task);
    void UpdateTask(TaskModel task);
    void DeleteTask(TaskModel task);
}