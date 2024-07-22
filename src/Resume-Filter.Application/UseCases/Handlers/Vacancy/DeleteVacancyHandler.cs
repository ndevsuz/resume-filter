using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Vacancy;

namespace Resume_Filter.Application.UseCases.Handlers.Vacancy;

public class DeleteVacancyHandler : IRequestHandler<DeleteVacancy, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteVacancyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteVacancy request, CancellationToken cancellationToken)
    {
        try
        {
            var vacancy = await _applicationDbContext.Vacancies.FirstOrDefaultAsync(vac=>vac.Id == request.Id);

            if (vacancy is null)
                return false;
            _applicationDbContext.Vacancies.Remove(vacancy);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

