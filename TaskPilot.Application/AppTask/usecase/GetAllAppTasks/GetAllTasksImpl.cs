using System;
using TaskPilot.Domain.Interfaces;
using TaskPilot.Domain.Entities;

namespace TaskPilot.Application.AppTask.usecase.GetAllAppTasks;

public class GetAllTasksImpl
{
    private readonly IAppTaskRepository _appTaskRepository;

    public GetAllTasksImpl(IAppTaskRepository appTaskRepository)
    {
        _appTaskRepository = appTaskRepository;
    }

    public async Task<IEnumerable<AppTaskEntity>> Execute()
    {
        return await _appTaskRepository.GetAllAsync();
    }

}
