using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Form;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class GetFormByVacancyIdHandler : IRequestHandler<GetFormByVacancyId, Forms>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetFormByVacancyIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Forms> Handle(GetFormByVacancyId request, CancellationToken cancellationToken)
    {
        Forms forms = await _applicationDbContext.Forms.FirstOrDefaultAsync(form=>form.VacancyId==request.VacancyId);
        return forms;
    }
}

