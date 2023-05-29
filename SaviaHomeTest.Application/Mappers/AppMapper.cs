using AutoMapper;
using SaviaHomeTest.Application.DTOs;
using SaviaHomeTest.Application.UseCases.TaskToDo.Commands.CreateTaskToDo;
using SaviaHomeTest.Domain.Entities;

namespace SaviaHomeTest.Application.Mappers;

/// <summary>
/// Custom mapper from Automaper
/// </summary>
public class AppMapper : Profile
{
    public AppMapper()
    {
        CreateMap<CreateTaskToDoCommand, TaskToDo>();
        CreateMap<TaskToDo, TaskToDoDto>();
    }

}
