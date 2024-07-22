using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Property;

namespace Resume_Filter.Application.UseCases.Handlers.Property;

public class DeletePropertyHandler : IRequestHandler<DeleteProperty, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeletePropertyHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteProperty request, CancellationToken cancellationToken)
    {
        try
        {
            var property = _applicationDbContext.Properties.FirstOrDefault(prop=>prop.Id==request.Id);

            if (property is null)
                return false;

            _applicationDbContext.Properties.Remove(property);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

