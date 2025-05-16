using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskPilot.Application.AppTask.usecase.CreateAppTask;
using TaskPilot.Application.AppTask.usecase.DeleteAppTask;
using TaskPilot.Application.AppTask.usecase.GetAllAppTasks;
using TaskPilot.Application.AppTask.usecase.UpdateAppTasks;
using TaskPilot.Domain.Interfaces;
using TaskPilot.Infra.Data.Context;
using TaskPilot.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
     options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskPilot API",
        Version = "v1"
    });
    options.EnableAnnotations(); 
    options.UseInlineDefinitionsForEnums();
}); 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=taskpilot.db"));

builder.Services.AddScoped<IAppTaskRepository, AppTaskRepository>();
builder.Services.AddScoped<CreateAppTaskImpl>();
builder.Services.AddScoped<DeleteAppTaskImpl>();
builder.Services.AddScoped<UpdateTaskImpl>();
builder.Services.AddScoped<GetAllTasksImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mapeia automaticamente os controllers

app.Run();
