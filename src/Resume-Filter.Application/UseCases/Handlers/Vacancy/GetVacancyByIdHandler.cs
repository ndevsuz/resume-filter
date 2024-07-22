using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Vacancy;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Handlers.Vacancy;

public class GetVacancyByIdHandler : IRequestHandler<GetVacancyById, Vacancies>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetVacancyByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Vacancies> Handle(GetVacancyById request, CancellationToken cancellationToken)
    {
        var vacancy = await _applicationDbContext.Vacancies.FirstOrDefaultAsync(vac=>vac.Id==request.Id);
        return vacancy;
    }
}

