using System;
using TaskPilot.Domain.Entities;
using TaskPilot.Domain.Interfaces;

namespace TaskPilot.Application.AppTask.usecase.CreateAppTask;

public class CreateAppTaskImpl
{
  private readonly IAppTaskRepository _appTaskRepository;
  public CreateAppTaskImpl(IAppTaskRepository appTaskRepository)
  {
    _appTaskRepository = appTaskRepository;
  }

  public async Task<CreateAppTaskResult> Execute(CreateAppTaskCommand command)
  {
      
    var appTask = new AppTaskEntity(
      command.Title,
      command.Description,
      command.Deadline,
      command.Priority
    );

    await _appTaskRepository.AddAsync(appTask);

    return new CreateAppTaskResult(appTask.Id);
  }

}
