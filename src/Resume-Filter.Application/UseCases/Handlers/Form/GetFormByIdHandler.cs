using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Form;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class GetFormByIdHandler : IRequestHandler<GetFormsById, Forms>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetFormByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Forms> Handle(GetFormsById request, CancellationToken cancellationToken)
    {
        Forms form = await _applicationDbContext.Forms.FirstOrDefaultAsync(form=>form.Id == request.Id);
        return form;
    }
}

