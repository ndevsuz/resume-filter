using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Vacancy;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Handlers.Vacancy;

public class UpdateVacancyHandler : IRequestHandler<UpdateVacancy, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateVacancyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public async Task<bool> Handle(UpdateVacancy request, CancellationToken cancellationToken)
    {
        try
        {
            Vacancies vacancy = await _applicationDbContext.Vacancies.FirstOrDefaultAsync(vac=>vac.Id==request.Id);

            if (vacancy is null)
                return false;
            vacancy.Name = request.Name ?? vacancy.Name;
            vacancy.Description = request.Description ?? vacancy.Description;
            vacancy.RecruiterId = request.RecruiterId ?? vacancy.RecruiterId;
            _applicationDbContext.Vacancies.Update(vacancy);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

