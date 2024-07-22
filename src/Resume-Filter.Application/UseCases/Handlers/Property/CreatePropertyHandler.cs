using AutoMapper;
using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Property;
using Resume_Filter.Domain.Entities.Property;

namespace Resume_Filter.Application.UseCases.Handlers.Property;

public class CreatePropertyHandler : IRequestHandler<CreateProperty, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreatePropertyHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateProperty request, CancellationToken cancellationToken)
    {
        try
        {
            Properties property = _mapper.Map<Properties>(request);
            await _applicationDbContext.Properties.AddAsync(property);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

