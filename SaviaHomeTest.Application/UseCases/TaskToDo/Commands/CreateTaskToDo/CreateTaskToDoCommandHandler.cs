using AutoMapper;
using MediatR;
using SaviaHomeTest.Application.Abstractions;
using SaviaHomeTest.Application.Responses;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Commands.CreateTaskToDo;

/// <summary>
/// MediatR command handler to create a TaskToDo
/// </summary>
public class CreateTaskToDoCommandHandler : IRequestHandler<CreateTaskToDoCommand, Response<Guid>>
{
    private readonly IAppRepository<Domain.Entities.TaskToDo> _TaskToDoRepository;
    private readonly IMapper _Mapper;

    public CreateTaskToDoCommandHandler(
        IAppRepository<Domain.Entities.TaskToDo> taskToDoRepository,
        IMapper mapper)
    {
        _TaskToDoRepository = taskToDoRepository;
        _Mapper = mapper;
    }

    /// <summary>
    /// Handle method of CreateTaskToDoCommandHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Response<Guid>> Handle(CreateTaskToDoCommand request, CancellationToken cancellationToken)
    {
        var taskToCreate = _Mapper.Map<Domain.Entities.TaskToDo>(request);
        var createdTaskToWriteDb = await _TaskToDoRepository.Save(taskToCreate);

        return (createdTaskToWriteDb != null)
            ? new Response<Guid>("Create TaskToDo", createdTaskToWriteDb.Id)
            : throw new Exception("Create TaskToDo failed");
    }
}
