using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Vacancy;

public class CreateVacancy:IRequest<bool>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int RecruiterID { get; set; }
}

