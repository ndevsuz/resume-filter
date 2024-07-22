using MediatR;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Queries.Vacancy;

public class GetAllVacancy:IRequest<List<Vacancies>>
{

}

