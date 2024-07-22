using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume_Filter.API.Helpers;
using Resume_Filter.Application.DTO.HR;
using Resume_Filter.Application.UseCases.Commands.HR;
using Resume_Filter.Application.UseCases.Queries.HR;

namespace Resume_Filter.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RecruiterController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RecruiterController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllRecruiters()
        => Ok(new Response
        { StatusCode=200,
          Message="Success",
          Data=await _mediator.Send(new GetAllRecruiters())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetRecruiterById(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new GetRecruiterById() { Id=Id})
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateRecruiter([FromForm]CreateRecruiterDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<CreateRecruiter>(dto))
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateRecruiter([FromForm]UpdateRecruiterDTO dto)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(_mapper.Map<UpdateRecruiter>(dto))
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteRecruiter(int Id)
        => Ok(new Response
        {
            StatusCode=200,
            Message="Success",
            Data = await _mediator.Send(new DeleteRecruiter() { Id=Id})
        });

}

