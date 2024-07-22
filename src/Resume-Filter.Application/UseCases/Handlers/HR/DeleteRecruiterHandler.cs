using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.HR;

namespace Resume_Filter.Application.UseCases.Handlers.HR;

public class DeleteRecruiterHandler : IRequestHandler<DeleteRecruiter, bool>
{
    public readonly IApplicationDbContext _applicationDbContext;

    public DeleteRecruiterHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteRecruiter request, CancellationToken cancellationToken)
    {
        try
        {
            var recruiter = await _applicationDbContext.Recruiters.FirstOrDefaultAsync(rec=>rec.Id ==request.Id);

            if (recruiter is null)
                return false;

            _applicationDbContext.Recruiters.Remove(recruiter);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

