using System;
using TaskPilot.Domain.Enums;

namespace TaskPilot.Application.AppTask.usecase;

public class CreateAppTaskCommand
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }

    public Priority Priority { get; set; } // <- deve ser direto, sem tipo `int`
}
