using System;
using TaskPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskPilot.Domain.Interfaces;
using TaskPilot.Infra.Data.Context;

namespace TaskPilot.Infra.Data.Repositories;

public class AppTaskRepository : IAppTaskRepository
{

  private readonly AppDbContext _context;

  public AppTaskRepository(AppDbContext context)
  {
    _context = context;
  }
  public async Task AddAsync(AppTaskEntity task)
  {
    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Guid id)
  {
    var appTask = await _context.Tasks.FindAsync(id);
    if (appTask is not null)
    {
      _context.Tasks.Remove(appTask);
      await _context.SaveChangesAsync();
    }
  }

  public async Task<IEnumerable<AppTaskEntity>> GetAllAsync()
  {
    return await _context.Tasks.ToListAsync();
  }

  public async Task<AppTaskEntity?> GetByIdAsync(Guid id)
  {
    return await _context.Tasks.FindAsync(id);
  }

  public async Task UpdateAsync(AppTaskEntity task)
  {
    _context.Tasks.Update(task);
    await _context.SaveChangesAsync();
  }
}
