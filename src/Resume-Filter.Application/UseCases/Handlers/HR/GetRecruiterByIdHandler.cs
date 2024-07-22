using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Queries.HR;
using Resume_Filter.Domain.Entities.HR;

namespace Resume_Filter.Application.UseCases.Handlers.HR;

public class GetRecruiterByIdHandler : IRequestHandler<GetRecruiterById, Recruiter>
{
    public IApplicationDbContext _applicationDbContext;

    public GetRecruiterByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Recruiter> Handle(GetRecruiterById request, CancellationToken cancellationToken)
    {
        var recruiter = await _applicationDbContext.Recruiters.FirstOrDefaultAsync(recr=>recr.Id == request.Id);
        return recruiter;
    }
}

