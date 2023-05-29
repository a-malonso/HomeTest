using AutoMapper;
using MediatR;
using SaviaHomeTest.Application.Abstractions;
using SaviaHomeTest.Application.DTOs;
using SaviaHomeTest.Application.Responses;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Queries.GetAllTasksToDo;

/// <summary>
/// MediatR query handler get all TaskToDo
/// </summary>
public class GetAllTasksToDoQueryHandler : IRequestHandler<GetAllTasksToDoQuery, Response<IEnumerable<TaskToDoDto>>>
{
    private readonly IAppRepository<Domain.Entities.TaskToDo> _TaskToDoRepository;
    private readonly IMapper _Mapper;

    public GetAllTasksToDoQueryHandler(
        IAppRepository<Domain.Entities.TaskToDo> taskToDoRepository,
        IMapper mapper)
    {
        _TaskToDoRepository = taskToDoRepository;
        _Mapper = mapper;
    }

    /// <summary>
    /// Handle method of GetAllTasksToDoQueryHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Response<IEnumerable<TaskToDoDto>>> Handle(GetAllTasksToDoQuery request, CancellationToken cancellationToken)
    {
        var tasksToDo = await _TaskToDoRepository.GetAll();

        var tasksToDoDto = _Mapper.Map<IEnumerable<TaskToDoDto>>(tasksToDo);

        return new Response<IEnumerable<TaskToDoDto>>("Get all TasksToDo", tasksToDoDto);
    }
}
