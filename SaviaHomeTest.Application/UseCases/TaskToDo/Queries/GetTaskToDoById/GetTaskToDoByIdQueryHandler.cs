using AutoMapper;
using MediatR;
using SaviaHomeTest.Application.Abstractions;
using SaviaHomeTest.Application.DTOs;
using SaviaHomeTest.Application.Responses;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetTaskToDoById
{
    /// <summary>
    /// MediatR query handler get one TaskToDo
    /// </summary>
    public class GetTaskToDoByIdQueryHandler : IRequestHandler<GetTaskToDoByIdQuery, Response<TaskToDoDto>>
    {
        private readonly IAppRepository<Domain.Entities.TaskToDo> _TaskToDoRepository;
        private readonly IMapper _Mapper;

        public GetTaskToDoByIdQueryHandler(
            IAppRepository<Domain.Entities.TaskToDo> taskToDoRepository,
            IMapper mapper)
        {
            _TaskToDoRepository = taskToDoRepository;
            _Mapper = mapper;
        }

        /// <summary>
        /// Handle method of GetTaskToDoByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<TaskToDoDto>> Handle(GetTaskToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var tasksToDo = await _TaskToDoRepository.GetById(request.Id);

            var taskToDoDto = _Mapper.Map<TaskToDoDto>(tasksToDo);

            return new Response<TaskToDoDto>("Get TaskToDo", taskToDoDto);
        }
    }
}
