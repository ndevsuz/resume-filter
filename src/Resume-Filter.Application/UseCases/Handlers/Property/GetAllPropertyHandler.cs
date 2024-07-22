using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Property;
using Resume_Filter.Domain.Entities.Property;

namespace Resume_Filter.Application.UseCases.Handlers.Property;

public class GetAllPropertyHandler : IRequestHandler<GetAllProperty, List<Properties>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllPropertyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Properties>> Handle(GetAllProperty request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Properties.ToListAsync(cancellationToken);
    }
}

