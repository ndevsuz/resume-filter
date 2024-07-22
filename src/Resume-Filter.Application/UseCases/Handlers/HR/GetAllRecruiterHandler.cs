using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.HR;
using Resume_Filter.Domain.Entities.HR;

namespace Resume_Filter.Application.UseCases.Handlers.HR;

public class GetAllRecruiterHandler : IRequestHandler<GetAllRecruiters, List<Recruiter>>
{
    public readonly IApplicationDbContext _applicationDbContext;

    public GetAllRecruiterHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Recruiter>> Handle(GetAllRecruiters request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Recruiters.ToListAsync(cancellationToken);
    }
}

