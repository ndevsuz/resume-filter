using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume_Filter.API.Helpers;
using Resume_Filter.Application.DTO.Property;
using Resume_Filter.Application.UseCases.Commands.Property;
using Resume_Filter.Application.UseCases.Queries.Property;

namespace Resume_Filter.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PropertyController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PropertyController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllProperties()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetAllProperty())
        });

    [HttpGet]
    public async ValueTask<IActionResult> GetPropertyById(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new GetPropertyById() { Id = Id })
        });

    [HttpPost]
    public async ValueTask<IActionResult> CreateProperty([FromForm]CreatePropertyDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<CreateProperty>(dto))
        });

    [HttpPut]
    public async ValueTask<IActionResult> UpdateProperty([FromForm]UpdatePropertyDTO dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(_mapper.Map<UpdateProperty>(dto))
        });

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteProperty(int Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _mediator.Send(new DeleteProperty() { Id = Id })
        });
}

