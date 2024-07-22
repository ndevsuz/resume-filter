using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume_Filter.API.Helpers;
using Resume_Filter.Application.DTO.Vacancy;
using Resume_Filter.Application.UseCases.Commands.Vacancy;
using Resume_Filter.Application.UseCases.Queries.Vacancy;

namespace Resume_Filter.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class VacancyController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VacancyController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllVacancies()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetAllVacancy())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetVacancyById(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetVacancyById() { Id = Id })
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateVacancy([FromForm]CreateVacancyDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<CreateVacancy>(dto))
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateVacancy([FromForm]UpdateVacancyDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<UpdateVacancy>(dto))
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteVacancy(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new DeleteVacancy() { Id = Id })
        });
}

