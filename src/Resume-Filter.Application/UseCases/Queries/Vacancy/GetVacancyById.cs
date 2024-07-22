using MediatR;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Queries.Vacancy;

public class GetVacancyById:IRequest<Vacancies>
{
    public int Id { get; set; }
}

