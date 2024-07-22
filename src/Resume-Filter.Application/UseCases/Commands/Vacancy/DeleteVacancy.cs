using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Vacancy;

public class DeleteVacancy:IRequest<bool>
{
    public int Id { get; set; }
}

