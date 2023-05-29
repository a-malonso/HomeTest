using MediatR;
using SaviaHomeTest.Application.DTOs;
using SaviaHomeTest.Application.Responses;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetTaskToDoById
{
    /// <summary>
    /// MediatR query to get one TaskToDo
    /// </summary>
    public class GetTaskToDoByIdQuery : IRequest<Response<TaskToDoDto>>
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
