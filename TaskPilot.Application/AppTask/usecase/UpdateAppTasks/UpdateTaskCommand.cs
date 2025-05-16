using System;
using TaskPilot.Domain.Enums;

namespace TaskPilot.Application.AppTask.usecase.UpdateAppTasks;

public class UpdateTaskCommand{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public Priority Priority { get; set; }
}
