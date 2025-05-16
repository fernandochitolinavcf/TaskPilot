using System;
using TaskPilot.Domain.Entities;
namespace TaskPilot.Domain.Interfaces;

public interface IAppTaskRepository
{
    Task<IEnumerable<AppTaskEntity>> GetAllAsync();
    Task<AppTaskEntity?> GetByIdAsync(Guid id);
    Task AddAsync(AppTaskEntity task);
    Task UpdateAsync(AppTaskEntity task);
    Task DeleteAsync(Guid id);
}
