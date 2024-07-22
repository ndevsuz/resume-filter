using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.HR;

namespace Resume_Filter.Application.UseCases.Handlers.HR;

public class UpdateRecruiterHandler : IRequestHandler<UpdateRecruiter, bool>
{
    public readonly IApplicationDbContext _applicationDbContext;

    public UpdateRecruiterHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateRecruiter request, CancellationToken cancellationToken)
    {
        try
        {
            var recruiter = await _applicationDbContext.Recruiters.FirstOrDefaultAsync(recr=>recr.Id == request.Id);

            if (recruiter is null)
                return false;

            recruiter.FirstName = request.FirstName ?? recruiter.FirstName;
            recruiter.LastName = request.LastName ?? recruiter.LastName;
            recruiter.Email = request.Email ?? recruiter.Email;
            recruiter.Password = request.Password ?? recruiter.Password;

            _applicationDbContext.Recruiters.Update(recruiter);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

