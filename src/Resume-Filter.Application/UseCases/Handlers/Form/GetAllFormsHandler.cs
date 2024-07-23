using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Form;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class GetAllFormsHandler : IRequestHandler<GetAllForms, List<Forms>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllFormsHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Forms>> Handle(GetAllForms request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Forms.ToListAsync(cancellationToken);
    }
}

