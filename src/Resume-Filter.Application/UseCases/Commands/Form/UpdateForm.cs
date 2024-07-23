using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Form;

public class UpdateForm:IRequest<bool>
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public int? VacancyId { get; set; }
    public string? Resume { get; set; }
}

