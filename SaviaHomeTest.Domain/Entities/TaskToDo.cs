using SaviaHomeTest.Domain.Enums;

namespace SaviaHomeTest.Domain.Entities;

/// <summary>
/// TaskToDo represents a task or activity you have to get done
/// </summary>
public class TaskToDo
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public Guid Id { get; init; }

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

    /// <summary>
    /// Indicates if the task has been deleted
    /// </summary>
    public bool IsDeleted { get; set; }
}
