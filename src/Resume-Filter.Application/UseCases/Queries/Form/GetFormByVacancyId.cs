using MediatR;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Queries.Form;

public class GetFormByVacancyId:IRequest<Forms>
{
    public int VacancyId { get; set; }
}