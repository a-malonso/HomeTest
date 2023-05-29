using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaviaHomeTest.Application.UseCases.TaskToDo.Commands.CreateTaskToDo;
using SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetAllTasksToDo;
using SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetTaskToDoById;

namespace SaviaHomeTest.API.Controllers.V1;

/// <summary>
/// TaskToDo controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TaskToDoController : ControllerBase
{
    protected readonly IMediator _mediator;

    /// <summary>
    /// Constructor that passes IMediator parameter to his base controller
    /// </summary>
    /// <param name="mediator">
    /// IMediator parameter to inject
    /// </param>
    public TaskToDoController(IMediator mediator)
    { 
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all TasksToDo
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllTasksToDo()
    {
        var query = new GetAllTasksToDoQuery();
        var result = await _mediator.Send(query);

        return (result.Data == null) ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Gets TaskToDo by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTasksToDoById(Guid id)
    {
        if(id == Guid.Empty) return BadRequest();

        var query = new GetTaskToDoByIdQuery() { Id=id };
        var result = await _mediator.Send(query);

        return (result.Data == null) ? NotFound(): Ok(result);
    }

    /// <summary>
    /// Creates a TaskToDo
    /// </summary>
    /// <param name="toDotaskToCreateCommand"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    public async Task<IActionResult> CreateToDoTask([FromBody] CreateTaskToDoCommand toDotaskToCreateCommand)
    {
        var result = await _mediator.Send(toDotaskToCreateCommand);

        return (result == null) ? throw new Exception() : CreatedAtAction("CreateToDoTask", new { taskToDoId = result.Data }, result);
    }
}
