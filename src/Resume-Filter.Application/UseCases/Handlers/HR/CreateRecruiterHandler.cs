using AutoMapper;
using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.HR;
using Resume_Filter.Domain.Entities.HR;
 
namespace Resume_Filter.Application.UseCases.Handlers.HR;

public class CreateRecruiterHandler : IRequestHandler<CreateRecruiter, bool>
{
    public readonly IApplicationDbContext _applicationDbContext;
    public readonly IMapper _mapper;
    

    public CreateRecruiterHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateRecruiter request, CancellationToken cancellationToken)
    {
        try
        {
            Recruiter recruiter = _mapper.Map<Recruiter>(request);
            await _applicationDbContext.Recruiters.AddAsync(recruiter);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

