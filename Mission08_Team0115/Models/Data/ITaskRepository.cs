using Microsoft.EntityFrameworkCore;
namespace Mission08_Team0115.Models;
public interface ITaskRepository
    {
        List<TaskModel> Tasks { get; }
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(TaskModel task);
    }
