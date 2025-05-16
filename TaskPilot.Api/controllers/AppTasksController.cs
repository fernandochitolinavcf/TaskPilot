using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPilot.Application.AppTask.usecase;
using TaskPilot.Application.AppTask.usecase.CreateAppTask;
using TaskPilot.Application.AppTask.usecase.GetAllAppTasks;
using TaskPilot.Application.AppTask.usecase.UpdateAppTasks;
using TaskPilot.Application.AppTask.usecase.DeleteAppTask;
using Swashbuckle.AspNetCore.Annotations;


namespace TaskPilot.Api.controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AppTasksController : ControllerBase
    {

        private readonly CreateAppTaskImpl _createAppTaskImpl;
        private readonly GetAllTasksImpl _getAllTasksImpl;
        private readonly UpdateTaskImpl _updateTaskImpl;
        private readonly DeleteAppTaskImpl _deleteTaskImpl;

        public AppTasksController(CreateAppTaskImpl createAppTaskImpl, GetAllTasksImpl getAllTasksImpl, UpdateTaskImpl updateTaskImpl, DeleteAppTaskImpl deleteTaskImpl)
        {
            _createAppTaskImpl = createAppTaskImpl;
            _deleteTaskImpl = deleteTaskImpl;
            _getAllTasksImpl = getAllTasksImpl;
            _updateTaskImpl = updateTaskImpl;
        }
             
        
        [HttpPost]
        [SwaggerOperation(Summary = "Create", Description = "Cria uma nova tarefa.")]
        public async Task<IActionResult> Create([FromBody] CreateAppTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Campos não preenchidos.");
            }

            var result = await _createAppTaskImpl.Execute(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "GetAll", Description = "Retorna todas as tarefas.")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllTasksImpl.Execute();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update", Description = "Atualiza uma tarefa.")]
        public async Task<IActionResult> Update(Guid id, UpdateTaskCommand command)
        {
            if (command == null)
            {
                return BadRequest("Campos não preenchidos.");
            }

            var result = await _updateTaskImpl.Execute(id, command);
            return Ok(result);
        }
      
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete", Description = "Remove uma tarefa.")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id não informado.");
            }

            var result = await _deleteTaskImpl.Execute(id);
            return Ok(result);
        }

    }
}
