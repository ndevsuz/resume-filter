using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.Property;
using Resume_Filter.Domain.Entities.Property;

namespace Resume_Filter.Application.UseCases.Handlers.Property;

public class GetPropertyByIdHandler : IRequestHandler<GetPropertyById, Properties>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetPropertyByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Properties> Handle(GetPropertyById request, CancellationToken cancellationToken)
    {
        var property = await _applicationDbContext.Properties.FirstOrDefaultAsync(prop=>prop.Id==request.Id);
        return property;
    }
}

