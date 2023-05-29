using SaviaHomeTest.Application.Responses;
using SaviaHomeTest.Domain.Enums;
using MediatR;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Commands.CreateTaskToDo;

/// <summary>
/// MediatR command to create a TaskToDo
/// </summary>
public class CreateTaskToDoCommand : IRequest<Response<Guid>>
{
    /// <summary>
    /// Short description of the task to do
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Priority level of the task to do
    /// </summary>
    public PriorityEnum Priority { get; set; }

    /// <summary>
    /// Indicates if the Task has been finished
    /// </summary>
    public bool IsDone { get; set; }
}
