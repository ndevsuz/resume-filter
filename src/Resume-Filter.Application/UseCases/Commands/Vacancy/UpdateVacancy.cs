using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Vacancy;

public class UpdateVacancy:IRequest<bool>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? RecruiterId { get; set; }
}

