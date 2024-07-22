using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Vacancy;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Handlers.Vacancy;

public class GetAllVacancyHandler : IRequestHandler<GetAllVacancy, List<Vacancies>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllVacancyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Vacancies>> Handle(GetAllVacancy request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Vacancies.ToListAsync(cancellationToken);
    }
}

