using SaviaHomeTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviaHomeTest.Application.DTOs
{
    /// <summary>
    /// TaskToDo DTO to send back
    /// </summary>
    public class TaskToDoDto
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
    }
}
