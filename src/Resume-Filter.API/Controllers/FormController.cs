using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume_Filter.API.Helpers;
using Resume_Filter.Application.DTO.Form;
using Resume_Filter.Application.DTO.HR;
using Resume_Filter.Application.UseCases.Commands.Form;
using Resume_Filter.Application.UseCases.Commands.HR;
using Resume_Filter.Application.UseCases.Queries.Form;
using Resume_Filter.Application.UseCases.Queries.HR;

namespace Resume_Filter.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FormController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FormController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllForms()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetAllForms())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetFormsById(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetFormsById() { Id = Id })
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetFormsByVacancyId(int VacancyId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetFormByVacancyId() { VacancyId = VacancyId })
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateForm([FromForm] CreateFormDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<CreateForm>(dto))
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteForm(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new DeleteForm() { Id = Id })
        });
}

