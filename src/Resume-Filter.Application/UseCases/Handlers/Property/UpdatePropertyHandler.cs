using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Property;

namespace Resume_Filter.Application.UseCases.Handlers.Property;

public class UpdatePropertyHandler : IRequestHandler<UpdateProperty, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdatePropertyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public async Task<bool> Handle(UpdateProperty request, CancellationToken cancellationToken)
    {
        try
        {
            var property = await _applicationDbContext.Properties.FirstOrDefaultAsync(prop=>prop.Id==request.Id);

            if (property is null)
                return false;

            property.Name = request.Name ?? property.Name;
            property.VacancyId = request.VacancyId ?? property.VacancyId;
            property.Value = request.Value ?? property.Value;


            _applicationDbContext.Properties.Update(property);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

