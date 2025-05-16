using TaskPilot.Domain.Enums;

namespace TaskPilot.Domain.Entities;

public class AppTaskEntity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime Deadline { get; private set; } 
    public Priority Priority { get; private set; }
    public TasksStatus Status { get; private set; }

    public AppTaskEntity(string title, string? description, DateTime deadline, Priority priority)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Deadline = deadline;
        Priority = priority;
        Status = TasksStatus.Pending;
    }

    public void Completed()
    {
        Status = TasksStatus.Completed;
    }

    public void Cancel()
    {
        Status = TasksStatus.Cancelled;
    }

    public void Update(string title, string? description, DateTime deadline, Priority priority)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Priority = priority;
    }
}
