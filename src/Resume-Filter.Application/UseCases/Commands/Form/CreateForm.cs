using MediatR;
using Microsoft.AspNetCore.Http;

namespace Resume_Filter.Application.UseCases.Commands.Form;

public class CreateForm:IRequest<bool>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int VacancyId { get; set; }
    public IFormFile Resume { get; set; }
}

