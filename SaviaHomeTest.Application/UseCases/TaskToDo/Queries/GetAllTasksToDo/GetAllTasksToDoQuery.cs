using MediatR;
using SaviaHomeTest.Application.DTOs;
using SaviaHomeTest.Application.Responses;
using SaviaHomeTest.Domain.Enums;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetAllTasksToDo;

/// <summary>
/// MediatR query handler to get all TaskToDo
/// </summary>
public class GetAllTasksToDoQuery : IRequest<Response<IEnumerable<TaskToDoDto>>>
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; }

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
