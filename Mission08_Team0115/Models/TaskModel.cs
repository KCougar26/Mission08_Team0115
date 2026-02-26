using System.ComponentModel.DataAnnotations;
using Mission08_Team0115.Models;
using System.ComponentModel.DataAnnotations.Schema;
public class TaskModel
{
    [Key]
    public int TaskId { get; set; }

    [Required] 
    public string TaskName { get; set; }

    public string? DueDate { get; set; } 

    [Required] 
    [Range(1, 4)] 
    public int Quadrant { get; set; }

    public bool Completed { get; set; } = false; 
    
    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}