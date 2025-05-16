using System;
using TaskPilot.Domain.Interfaces;

namespace TaskPilot.Application.AppTask.usecase.DeleteAppTask;

public class DeleteAppTaskImpl
{
  private readonly IAppTaskRepository _appTaskRepository;

  public DeleteAppTaskImpl(IAppTaskRepository appTaskRepository)
  {
    _appTaskRepository = appTaskRepository;
  }

  public async Task<bool> Execute(Guid id)
  {
    var appTask = await _appTaskRepository.GetByIdAsync(id);

    if (appTask == null)
    {
      throw new Exception("Nenhuma tarefa encontada para o id informado.");
    }

    await _appTaskRepository.DeleteAsync(id);
    return true;
  }
}
