using System;
using TaskPilot.Domain.Interfaces;

namespace TaskPilot.Application.AppTask.usecase.UpdateAppTasks;

public class UpdateTaskImpl
{

  private readonly IAppTaskRepository _appTaskRepository;

  public UpdateTaskImpl(IAppTaskRepository appTaskRepository)
  {
    _appTaskRepository = appTaskRepository;
  }

  public async Task<bool> Execute(Guid id, UpdateTaskCommand command)
  {
    var appTask = await _appTaskRepository.GetByIdAsync(id);

    if (appTask == null)
    {
      throw new Exception("Nenhuma tarefa encontada para o id informado.");
    }

    appTask.Update(
      command.Title,
      command.Description,
      command.Deadline,
      command.Priority
    );

    await _appTaskRepository.UpdateAsync(appTask);

    return true;
  }

}
